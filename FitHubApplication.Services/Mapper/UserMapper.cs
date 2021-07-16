using FitHubApplication.Models;
using FitHubApplication.Models.Entities;

namespace FitHubApplication.Services.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email,
            };
        }

        public static User ToUser(this UserDto user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.Username,
                Email = user.Email,
            };
        }
    }
}
