using QueueManagementSystem.Application.Categories.QueryModels.Common;
using QueueManagementSystem.Application.Categories.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
    public class CategoryMapper : MappingProfile
    {
        public CategoryMapper()
        {
            BuildMap<Category, CategoryQueryModel>();
            BuildMap<Category, CategoryViewModel>();
        }
    }
}