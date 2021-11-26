using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
    public class WorkerScheduleRepository : BaseRepository<WorkerSchedule>, IWorkerScheduleRepository
    {
        public WorkerScheduleRepository(IContext db)
            : base(db)
        {
        }
    }
}