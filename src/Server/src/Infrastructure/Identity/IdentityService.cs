using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Authorization.Queries;
using QueueManagementSystem.Domain.Common;
using QueueManagementSystem.Domain.Exceptions;
using IAuthorizationService = Microsoft.AspNetCore.Authorization.IAuthorizationService;

namespace QueueManagementSystem.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IJwtTokenProvider jwtTokenProvider;
        private readonly IUserClaimsPrincipalFactory<IdentityUser> userClaimsPrincipalFactory;
        private readonly UserManager<IdentityUser> userManager;

        public IdentityService(UserManager<IdentityUser> userManager
            , IJwtTokenProvider jwtTokenProvider
            , IUserClaimsPrincipalFactory<IdentityUser> userClaimsPrincipalFactory
            , IAuthorizationService authorizationService)
        {
            this.userManager = userManager;
            this.jwtTokenProvider = jwtTokenProvider;
            this.userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            this.authorizationService = authorizationService;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<Result> AddRoleToAsync(string userId, string role)
        {
            var applicationUser = await userManager.FindByIdAsync(userId);
            var identityResult = await userManager.AddToRoleAsync(applicationUser, role);
            return identityResult.ToApplicationResult();
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string login, string email, string password,
            string userId = null)
        {
            var user = new IdentityUser
            {
                Id = userId ?? Guid.NewGuid().ToString(),
                UserName = login,
                Email = email
            };

            var result = await userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<bool> Authorize(string userId, string policyName)
        {
            var applicationUser = await userManager.Users.SingleOrDefaultAsync(user => user.Id == userId);

            var principal = await userClaimsPrincipalFactory.CreateAsync(applicationUser);

            var authorizationResult = await authorizationService.AuthorizeAsync(principal, policyName);
            return authorizationResult.Succeeded;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            return await userManager.IsInRoleAsync(user, role);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new NotFoundException(nameof(IdentityUser), userId);
            }

            await userManager.DeleteAsync(user);
            return Result.Success();
        }

        public async Task<GetTokenByUserNameAndPasswordResult> GetTokenAsync(string username, string password)
        {
            var applicationUser = await userManager.FindByNameAsync(username);
            if (applicationUser is null)
                return GetTokenByUserNameAndPasswordResult.Failure();

            var isPasswordValid = await userManager.CheckPasswordAsync(applicationUser, password);

            //invalid
            if (!isPasswordValid)
                return GetTokenByUserNameAndPasswordResult.Failure();

            //valid and generate token
            var roles = await userManager.GetRolesAsync(applicationUser);
            var token = jwtTokenProvider.GenerateAsync(applicationUser, roles);
            return GetTokenByUserNameAndPasswordResult.Success(token, username);
        }
    }
}