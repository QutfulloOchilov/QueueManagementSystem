using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QueueManagementSystem.Application.QueryModels;
using QueueManagementSystem.Application.ViewModel;
using QueueManagementSystem.Application.ViewModels;
using QueueManagementSystem.Domain.Interfaces;

namespace QueueManagementSystem.Application.Services
{
    public interface IService<TEntity, TViewModel, TQueryModel>
        where TEntity : class, IEntity
        where TViewModel : BaseViewModel
        where TQueryModel : BaseQueryModel
    {
        Task<IEnumerable<TViewModel>> GetAll();
        Task<PagedListViewModel<TViewModel>> GetPagedList(int pageIndex, int pageSize);
        Task<TViewModel> GetById(Guid id);
        Task<TViewModel> Create(TQueryModel newEntity);
        Task<TViewModel> Update(TQueryModel updateEntity);
        Task Delete(Guid id);
    }
}