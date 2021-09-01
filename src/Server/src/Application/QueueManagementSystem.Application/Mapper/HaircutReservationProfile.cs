using QueueManagementSystem.Application.Users.QueryModels;
using QueueManagementSystem.Application.Users.ViewModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class HaircutReservationProfile : MappingProfile
	{
		public HaircutReservationProfile()
		{
			BuildMap<HaircutReservation, UserReservationViewModel>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			base.BuildMap<HaircutReservation, ReserveHaircutQueryModel>();
			CreateMap<TSource, TDestination>()
				.ForPath(dest => (dest as UserReservationViewModel).Price, opt => opt.MapFrom(src => (src as HaircutReservation).ServiceDetail.Price))
				.ForPath(dest => (dest as UserReservationViewModel).WorkerName, opt => opt.MapFrom(src => (src as HaircutReservation).ServiceDetail.Worker));

			CreateMap<HaircutReservation, WorkerReservationViewModel>()
				.ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User))
				.ForPath(dest => dest.Price, opt => opt.MapFrom(src => src.ServiceDetail.Price));
		}
	}
}
