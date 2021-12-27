using QueueManagementSystem.Application.Categories.QueryModels;
using QueueManagementSystem.Application.Categories.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Categories.Services
{
    public interface ICategoryService : IService<Category, CategoryViewModel, CategoryBaseQueryModel>
    {
    }
}