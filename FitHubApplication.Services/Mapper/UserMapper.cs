using FitHubApplication.Models.AppEnums;
using FitHubApplication.Models.Entities;
using FitHubApplication.Services.Extensions;

namespace FitHubApplication.Services.Mapper
{
    public static class UserMapper
    {

        /// <summary>
        /// Converts a <see cref="User"/> to <see cref="UserDto"/>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserDto EntityToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email,
                Gender = user.Gender.GetDisplayName(),
                Level = user.Level.GetDisplayName(),
                DateOfBirth = user.DateOfBirth,
                Description = user.Description,
                Height = user.Height,
                Weight = user.Weight,
                ProfilePictureBase = !(user.ProfilePicture is null) ? user.ProfilePicture.FilePath.ToBase64() : string.Empty,
            };
        }

        /// <summary>
        /// Converts a <see cref="UserDto"/> to <see cref="User"/>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User DtoToEntity(this UserDto user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.Username,
                Email = user.Email,
                Gender = user.Gender.ToEnum<Enums.Gender>(),
                Level = user.Level.ToEnum<Enums.Level>(),
                DateOfBirth = user.DateOfBirth,
                Description = user.Description,
                Height = user.Height,
                Weight = user.Weight,
            };
        }

        /// <summary>
        /// Converts a <see cref="CreateUserDto"/> to <see cref="User"/>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User CreateDtoToEntity(this CreateUserDto user)
        {
            return new User
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.Username,
                Email = user.Email,
                Gender = user.Gender.ToEnum<Enums.Gender>(),
                Level = user.Level.ToEnum<Enums.Level>(),
                DateOfBirth = user.DateOfBirth,
                Description = user.Description,
                Height = user.Height,
                Weight = user.Weight,
                ProfilePictureId = user.ProfilePictureId,
            };
        }
    }
}
