using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.Users.QueryModels;
using QueueManagementSystem.Application.Users.ViewModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Users.Services
{
    public interface IUserService : IService<User, UserViewModel, UserBaseQueryModel>
    {
        Task<UserReservationViewModel> ReserveHaircut(ReserveHaircutQueryModel model);
        Task CancelReservation(CancelReservationQueryModel model);
        Task<IEnumerable<UserReservationViewModel>> GetReservations(Guid userId);
        Task<FreeTimeViewModel> GetFreeTime(GetFreeTimeQueryModel model);
    }
}