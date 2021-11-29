using QueueManagementSystem.Application.Users.QueryModels.Common;
using QueueManagementSystem.Application.Users.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
    public class UserProfile : MappingProfile
    {
        public UserProfile()
        {
            BuildMap<User, UserViewModel>();
            BuildMap<User, UserQueryModel>();
        }
    }
}