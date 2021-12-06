using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.QueryModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.ViewModel;
using QueueManagementSystem.Application.ViewModels;
using QueueManagementSystem.Domain.Interfaces;

namespace QueueManagementSystem.Services
{
    public class BaseService<TEntity, TViewModel, TQueryModel> : IService<TEntity, TViewModel, TQueryModel>
        where TEntity : class, IEntity
        where TViewModel : BaseViewModel
        where TQueryModel : BaseQueryModel
    {
        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity> repository, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            Mapper = mapper;
        }

        public IUnitOfWork UnitOfWork { get; }
        public IRepository<TEntity> Repository { get; }
        public IMapper Mapper { get; }

        public async Task<IEnumerable<TViewModel>> GetAll()
        {
            var entities = await Repository.GetAllAsync();
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(entities);
        }

        public async Task<TViewModel> GetById(Guid id)
        {
            var entity = await FindByIdAsync(id);

            return Mapper.Map<TEntity, TViewModel>(entity);
        }

        public virtual async Task<TViewModel> Create(TQueryModel newEntity)
        {
            var entity = await CreateAndMakeSureSaved(newEntity);
            return Mapper.Map<TEntity, TViewModel>(entity);
        }

        public virtual async Task<TViewModel> Update(TQueryModel updateEntity)
        {
            var entityToBeUpdated = await FindByIdAsync(updateEntity.Id);
            Mapper.Map(updateEntity, entityToBeUpdated);
            await UnitOfWork.SaveChangesAsync();
            return Mapper.Map<TEntity, TViewModel>(entityToBeUpdated);
        }

        public async Task Delete(Guid id)
        {
            var entity = await FindByIdAsync(id);
            var canDelete = CanEntityBeDeleted(entity);
            if (!canDelete.CanBeDeleted)
                throw new BusinessLogicException($"{entity.Title} cannot be deleted because {canDelete.Reason}");

            Repository.Delete(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedListViewModel<TViewModel>> GetPagedList(int pageIndex, int pageSize)
        {
            var pagedList = await Repository.GetPagedListAsync(null, null, pageIndex, pageSize, false);
            var viewModel = new PagedListViewModel<TViewModel>
            {
                IndexFrom = pagedList.IndexFrom,
                PageIndex = pagedList.PageIndex,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                HasPreviousPage = pagedList.HasPreviousPage,
                HasNextPage = pagedList.HasNextPage,
                Items = Mapper.Map<IEnumerable<TViewModel>>(pagedList.Items)
            };
            return viewModel;
        }

        protected async Task<TEntity> FindByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new BusinessLogicException("The Id shouldn't be empty to get an entity.");

            var entity = await Repository.GetByIdAsync(id);

            if (entity == null)
                throw new BusinessLogicException("An entity was not found with a provided Id.");

            return entity;
        }

        protected virtual (bool CanBeDeleted, string Reason) CanEntityBeDeleted(TEntity entity)
        {
            return (true, "");
        }

        private async Task<TEntity> CreateAndMakeSureSaved(TQueryModel queryModel)
        {
            var newEntity = await CreateEntity(queryModel);
            await UnitOfWork.SaveChangesAsync();

            //var createdEntity = await Repository.GetByIdAsync(newEntity.Id);
            //if (createdEntity == null)
            //    throw new Exception($"{typeof(TEntity).Name} was not created with an unknown reason.");     //REVIEW: NLog with Appcenter

            return newEntity;
        }

        protected async Task<TEntity> CreateEntity(TQueryModel queryModel)
        {
            var newEntity = Mapper.Map<TEntity>(queryModel);
            await Repository.AddAsync(newEntity);
            return newEntity;
        }
    }
}