using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;

namespace QueueManagementSystem.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            BuildRepositories(serviceProvider);
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        #region Properties

        public IUserRepository PersonRepository { get; private set; }

        #endregion

        public IContext Context { get; }

        public int? CommandTimeout
        {
            get => Context.CommandTimeout;
            set => Context.CommandTimeout = value;
        }

        public virtual void Rollback()
        {
            Context.UndoChanges();
        }

        void BuildRepositories(IServiceProvider serviceProvider)
        {
            PersonRepository = serviceProvider.GetService<IUserRepository>();
        }

        #region SaveChanges

        public virtual int SaveChanges() => Context.SaveChanges();

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }

        #endregion

        #region ExecuteSqlCommand

        [Obsolete]
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Context.ExecuteSqlCommand(sql, parameters);
        }

        public virtual Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return Context.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken,
            params object[] parameters)
        {
            return Context.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        #endregion
    }
}