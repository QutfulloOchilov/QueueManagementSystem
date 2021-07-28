using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<Person>, IUserRepository
    {
        public UserRepository(IContext dbContext)
            : base(dbContext)
        {

        }
    }
}
