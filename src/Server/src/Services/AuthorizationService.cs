using System.Threading.Tasks;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Authorization.Queries;

namespace QueueManagementSystem.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IIdentityService identityService;

        public AuthorizationService(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public Task<GetTokenByUserNameAndPasswordResult> GetTokenAsync(GetTokenByUserAndPasswordQuery query)
        {
            return identityService.GetTokenAsync(query.Login, query.Password);
        }
    }
}