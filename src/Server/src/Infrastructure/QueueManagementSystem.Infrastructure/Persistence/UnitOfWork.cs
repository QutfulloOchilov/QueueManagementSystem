using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace QueueManagementSystem.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IContext Context { get; }
        public IServiceProvider ServiceProvider { get; }

        public UnitOfWork(IContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            BuildRepositories(serviceProvider);
            ServiceProvider = serviceProvider;
        }

        void BuildRepositories(IServiceProvider serviceProvider)
        {
            PersonRepository = serviceProvider.GetService<IPersonRepository>();
        }

        #region Properties
        public IPersonRepository PersonRepository { get; private set; }
        #endregion

        public int? CommandTimeout
        {
            get => Context.CommandTimeout;
            set => Context.CommandTimeout = value;
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
            return await this.SaveChangesAsync(cancellationToken) > 0 ? true : false;
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

        public virtual Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return Context.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }
        #endregion

        public virtual void Rollback()
        {
            Context.UndoChanges();
        }
    }
}
