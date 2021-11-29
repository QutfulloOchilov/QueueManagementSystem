using System.Threading.Tasks;
using QueueManagementSystem.Application.Authorization.Queries;
using QueueManagementSystem.Domain.Common;

namespace QueueManagementSystem.Application.Abstraction
{
    public interface IIdentityService
    {
        Task<bool> IsInRoleAsync(string userId, string role);

        Task<Result> AddRoleToAsync(string userId, string role);

        Task<(Result Result, string UserId)> CreateUserAsync(string login, string email, string password, string userId = null);

        Task<bool> Authorize(string userId, string policyName);

        Task<Result> DeleteUserAsync(string userId);
        Task<GetTokenByUserNameAndPasswordResult> GetTokenAsync(string username, string password);
    }
}