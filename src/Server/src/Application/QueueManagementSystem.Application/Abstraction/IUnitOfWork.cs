using System.Threading;
using System.Threading.Tasks;

namespace QueueManagementSystem.Application.Abstraction
{
    public interface IUnitOfWork
    {
        IContext Context { get; }
        int? CommandTimeout { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
        int ExecuteSqlCommand(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default, params object[] parameters);
        void Rollback();
    }
}
