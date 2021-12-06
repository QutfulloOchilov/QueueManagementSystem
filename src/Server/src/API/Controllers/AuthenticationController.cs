using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Authorization.Queries;

namespace QueueManagementSystem.API.Controllers
{  
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;

        public AuthenticationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        [HttpPost]
        public Task<GetTokenByUserNameAndPasswordResult> Login([FromBody] GetTokenByUserAndPasswordQuery query) =>
            authorizationService.GetTokenAsync(query);
    }
}