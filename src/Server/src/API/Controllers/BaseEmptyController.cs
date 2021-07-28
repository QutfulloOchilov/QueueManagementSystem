using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.QueryModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.ViewModel;
using QueueManagementSystem.Domain.Interfaces;

namespace QueueManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
	[Authorize]
	public class BaseEmptyController<TEntity, TViewModel, TQueryModel, TService> : ControllerBase
        where TEntity : class, IEntity
        where TViewModel : BaseViewModel
        where TQueryModel : BaseQueryModel
        where TService : IService<TEntity, TViewModel, TQueryModel>
    {
        public TService Service { get; }

        public BaseEmptyController(TService service)
        {
            Service = service;
        }
    }
}
