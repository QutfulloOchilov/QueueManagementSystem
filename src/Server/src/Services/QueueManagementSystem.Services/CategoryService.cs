using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Categories.QueryModels;
using QueueManagementSystem.Application.Categories.Services;
using QueueManagementSystem.Application.Categories.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
	public class CategoryService : BaseService<Category, CategoryViewModel, CategoryBaseQueryModel>, ICategoryService
	{
		public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository repository, IMapper mapper)
			: base(unitOfWork, repository, mapper)
		{

		}
	}
}
