using QueueManagementSystem.Application.Businesses.QueryModels;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Businesses.Services
{
	public interface IBusinessService : IService<Business, BusinessViewModel, BusinessBaseQueryModel>
	{
	}
}
