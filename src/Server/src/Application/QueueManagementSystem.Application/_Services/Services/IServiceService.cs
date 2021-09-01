using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application._Services.QueryModels;
using QueueManagementSystem.Application._Services.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Domain.Entities;
using System.Threading.Tasks;

namespace QueueManagementSystem.Application._Services.Services
{
	public interface IServiceService : IService<Service, ServiceViewModel, ServiceBaseQueryModel>
	{
	}
}
