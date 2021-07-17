using FitHubApplication.Models.AppEnums;
using FitHubApplication.Models.Entities;
using FitHubApplication.Services.Extensions;

namespace FitHubApplication.Services.Mapper
{
    public static class UserMapper
    {
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
