using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace QueueManagementSystem.Infrastructure.Identity
{
    public interface IJwtTokenProvider
    {
        string GenerateAsync(IdentityUser identityUser, IEnumerable<string> roles);
    }
}