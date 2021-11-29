using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace QueueManagementSystem.Infrastructure.Identity
{
    public static class SigningKeyProvider
    {
        public static SymmetricSecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_deployer_secret"));
        }
    }
}