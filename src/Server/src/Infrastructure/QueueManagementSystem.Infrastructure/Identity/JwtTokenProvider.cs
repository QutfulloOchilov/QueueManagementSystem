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
        private readonly AuthOptions _authOptions;

        public JwtTokenProvider(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }

        public string GenerateAsync(IdentityUser identityUser, IEnumerable<string> roles)
        {
            var audience = _authOptions.TokenAudience;
            var lifetime = TimeSpan.FromMinutes(_authOptions.AccessTokenLifeTime);
            return GenerateAccessToken(identityUser, audience, lifetime, roles);
        }

        private string GenerateAccessToken(IdentityUser user, string audience, TimeSpan lifetime,
            IEnumerable<string> roles)
        {
            var now = DateTime.UtcNow;
            var signingCredentials =
                new SigningCredentials(SigningKeyProvider.GetSecurityKey(), SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email)
            };
            roles.ForAll(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            var securityToken = new JwtSecurityToken(
                _authOptions.TokenIssuer,
                audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(lifetime),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}