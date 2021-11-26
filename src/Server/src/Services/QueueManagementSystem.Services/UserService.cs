using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Users.QueryModels;
using QueueManagementSystem.Application.Users.Services;
using QueueManagementSystem.Application.Users.ViewModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
    public class UserService : BaseService<User, UserViewModel, UserBaseQueryModel>, IUserService
    {
        private readonly IJobDetailRepository jobDetailRepo;
        private readonly IMapper mapper;
        private readonly IWorkerRepository workerRepo;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository, IWorkerRepository _workerRepo,
            IJobDetailRepository _jobDetailRepo, IMapper _mapper)
            : base(unitOfWork, repository, _mapper)
        {
            jobDetailRepo = _jobDetailRepo;
            mapper = _mapper;
            workerRepo = _workerRepo;
        }

        public async Task<UserReservationViewModel> ReserveHaircut(ReserveHaircutQueryModel model)
        {
            var user = await Repository.GetByIdAsync(model.UserId);
            var jobDetail = await jobDetailRepo.GetByIdAsync(model.JobDetailId);

            if (jobDetail == null)
                throw new BusinessLogicException("Job was not found with a provided Id.");

            var haircutReservation = mapper.Map<HaircutReservation>(model);
            user.Reservations.Add(haircutReservation);
            await UnitOfWork.SaveChangesAsync();
            return mapper.Map<UserReservationViewModel>(haircutReservation);
        }

        public async Task CancelReservation(CancelReservationQueryModel model)
        {
            var user = await Repository.GetByIdAsync(model.UserId);
            var reservation = user.Reservations.FirstOrDefault(r => r.Id == model.ReservationId);

            if (reservation == null)
                throw new BusinessLogicException("Reservation was not found with a privided Id.");

            user.Reservations.Remove(reservation);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserReservationViewModel>> GetReservations(Guid userId)
        {
            var reservations = (await Repository.GetByIdAsync(userId)).Reservations;
            return mapper.Map<IEnumerable<UserReservationViewModel>>(reservations);
        }

        public async Task<FreeTimeViewModel> GetFreeTime(GetFreeTimeQueryModel model)
        {
            List<TimeIntervalViewModel> reservations = new List<TimeIntervalViewModel>();

            var worker = await workerRepo.GetByIdAsync(model.WorkerId);
            int duration = worker.JobDetails.Find(sd => sd.JobId == model.JobId).Duration;

            worker.JobDetails.Where(sd => sd.JobId == model.JobId).ToList().ForEach(sd =>
            {
                sd.HaircutReservations.Where(hr => hr.From.Date == model.ReservationDate.Date).ToList().ForEach(res =>
                    reservations.Add(new TimeIntervalViewModel
                    {
                        From = res.From,
                        To = res.To
                    }));
            });

            WorkerSchedule workerSchedule =
                worker.WorkerSchedules.FirstOrDefault(ws => ws.DayOfWeek == model.ReservationDate.Date.DayOfWeek);

            if (workerSchedule == null)
                throw new BusinessLogicException($"On {model.ReservationDate.Date} worker doesn't work");

            if (reservations.Count == 0)
                return new FreeTimeViewModel
                {
                    TimeIntervals = new List<TimeIntervalViewModel>
                    {
                        new TimeIntervalViewModel(model.ReservationDate, workerSchedule)
                    }
                };

            return new FreeTimeViewModel
                { TimeIntervals = GetTimeIntervals(reservations, duration, model, workerSchedule) };
        }

        List<TimeIntervalViewModel> GetTimeIntervals(List<TimeIntervalViewModel> reservations, int duration,
            GetFreeTimeQueryModel model, WorkerSchedule workerSchedule)
        {
            List<TimeIntervalViewModel> intervals = new List<TimeIntervalViewModel>();

            DateTime requestedTime;

            if (model.ReservationDate == DateTime.Today && (IsInWorkTime(workerSchedule, duration) ||
                                                            DateTime.Now.Hour >= workerSchedule.End.Hour))
                requestedTime = DateTime.Now;
            else
                requestedTime = new DateTime(model.ReservationDate.Year, model.ReservationDate.Month,
                    model.ReservationDate.Day, workerSchedule.Start.Hour, workerSchedule.Start.Minute, 0);

            for (int i = 0; i < reservations.Count + 1; i++)
            {
                if (i == reservations.Count)
                {
                    var endOfWorkingDay = new DateTime(model.ReservationDate.Year, model.ReservationDate.Month,
                        model.ReservationDate.Day, workerSchedule.End.Hour, workerSchedule.End.Minute, 0);

                    if (endOfWorkingDay - requestedTime >= TimeSpan.FromMinutes(duration)
                        && endOfWorkingDay - reservations[i - 1].To >= TimeSpan.FromMinutes(duration))
                    {
                        intervals.Add(new TimeIntervalViewModel
                        {
                            From = requestedTime > reservations[i - 1].To ? requestedTime : reservations[i - 1].To,
                            To = endOfWorkingDay
                        });
                    }
                }
                else if (i == 0)
                {
                    if (reservations[0].From.Subtract(TimeSpan.FromMinutes(duration)) >= requestedTime)
                    {
                        intervals.Add(new TimeIntervalViewModel
                        {
                            From = requestedTime,
                            To = reservations[0].From.AddMinutes(-duration)
                        });
                    }
                }
                else
                {
                    if (reservations[i].From - requestedTime >= TimeSpan.FromMinutes(duration)
                        && reservations[i].From - reservations[i - 1].To > TimeSpan.FromMinutes(duration))
                    {
                        intervals.Add(new TimeIntervalViewModel
                        {
                            From = requestedTime > reservations[i - 1].To ? requestedTime : reservations[i - 1].To,
                            To = reservations[i].From.AddMinutes(-duration)
                        });
                    }
                }
            }

            return intervals;
        }

        bool IsInWorkTime(WorkerSchedule workerSchedule, int duration)
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                workerSchedule.Start.Hour, workerSchedule.Start.Minute, 0);
            DateTime end = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                workerSchedule.End.Hour, workerSchedule.End.Minute, 0);

            return DateTime.Now >= start && DateTime.Now < end.AddMinutes(-duration);
        }
    }
}