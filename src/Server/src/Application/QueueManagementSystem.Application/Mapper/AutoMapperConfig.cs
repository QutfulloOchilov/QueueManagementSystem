using AutoMapper;

namespace QueueManagementSystem.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapQueryModels();
            MapViewModel();
        }

        void MapQueryModels()
        {

        }

        void MapViewModel()
        {
        }

        protected virtual void BuildMap<TSource, TDestination>()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}
