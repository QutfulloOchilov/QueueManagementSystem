using Microsoft.AspNetCore.Hosting.Server;

namespace QueueManagementSystem.Application.Authorization.Queries
{
    public class GetTokenByUserAndPasswordQuery
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}