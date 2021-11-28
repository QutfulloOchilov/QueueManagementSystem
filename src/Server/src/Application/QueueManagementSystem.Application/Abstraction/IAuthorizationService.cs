using System.Threading.Tasks;
using QueueManagementSystem.Application.Authorization.Queries;

namespace QueueManagementSystem.Application.Abstraction
{
    public interface IAuthorizationService
    {
        public Task<GetTokenByUserNameAndPasswordResult> GetTokenAsync(GetTokenByUserAndPasswordQuery query);
    }
}