using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace QueueManagementSystem.Infrastructure.Identity
{
    public class JwtTokenProvider : AuthenticatorTokenProvider<IdentityUser>, IJwtTokenProvider
    {
        private readonly AuthOptions authOptions;

        public JwtTokenProvider(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions.Value;
        }

        public string GenerateAsync(IdentityUser identityUser, IEnumerable<string> roles)
        {
            var audience = authOptions.TokenAudience;
            var lifetime = TimeSpan.FromMinutes(authOptions.AccessTokenLifeTime);
            return GenerateAccessToken(identityUser, audience, lifetime, roles);
        }

        private string GenerateAccessToken(IdentityUser user, string audience, TimeSpan lifetime,
            IEnumerable<string> roles)
        {
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(SigningKeyProvider.GetSecurityKey(), SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName)
            };
            roles.ForAll(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            var securityToken = new JwtSecurityToken(
                authOptions.TokenIssuer,
                audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(lifetime),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}