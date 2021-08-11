using FitHubApplication.Models.AppEnums;
using FitHubApplication.Models.Constants;
using FitHubApplication.Models.Entities;
using FitHubApplication.Repositories;
using FitHubApplication.Services.Exceptions;
using FitHubApplication.Services.Extensions;
using FitHubApplication.Services.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task<List<UserDto>> Search(UserSearchInput input)
        {
            IQueryable<User> query = userRepository.GetAll()
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Name), x => x.Name.Contains(input.Name))
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Surname), x => x.Surname.Contains(input.Surname))
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Gender), x => x.Gender.Equals(input.Gender.ToEnum<Enums.Gender>()))
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Level), x => x.Level.Equals(input.Level.ToEnum<Enums.Level>()))
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Email), x => x.Email.Contains(input.Email))
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Username), x => x.UserName.Contains(input.Username))
                    .WhereIf(input.Weight.HasValue, x => x.Weight.Equals(input.Weight.Value))
                    .WhereIf(input.Height.HasValue, x => x.Height.Equals(input.Height.Value))
                    .WhereIf(input.DateOfBirth.HasValue, x => x.DateOfBirth.Value.Equals(input.DateOfBirth.Value));

            List<UserDto> users = await query
                .Skip(input.SkipCount)
                .Take(input.TakeCount)
                .Select(x => x.EntityToDto())
                .ToListAsync();

            return users;
        }

        public async Task<UserDto> GetById(string id)
        {
            User user = await userManager.Users.Include(x => x.ProfilePicture).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return user.EntityToDto();
        }

        public async Task<User> Get(string usernameOrEmail)
        {
            User user = await userRepository.GetFirstWhere(x => x.Email.Equals(usernameOrEmail) || x.UserName.Equals(usernameOrEmail));

            ExceptionHelper.NullCheck<User>(user, ApplicationConsts.ExceptionMessages.UserIsNull);

            return user;
        }

        public async Task CreateAsync(CreateUserDto user, string plainPassword)
        {
            await userManager.CreateAsync(user.CreateDtoToEntity(), plainPassword);
        }

        public async Task UpdateAsync(UserDto user)
        {
            await userManager.UpdateAsync(user.DtoToEntity());
        }

        public async Task DeleteAsync(string id)
        {
            User user = new User
            {
                Id = id
            };

            await userManager.DeleteAsync(user);
        }
    }
}