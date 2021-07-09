using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Repositories;
using FitHubApplication.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
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

        public async Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return await userManager.GetClaimsAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await userRepository.GetAll().ToListAsync();
        }

        public async Task<List<User>> GetByName(string name)
        {
            return await userRepository.GetWhere(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await userRepository.GetFirstWhere(x => x.Id.Equals(id));
        }

        public async Task<User> Get(string usernameOrEmail)
        {
            User user = await userRepository.GetFirstWhere(x => x.Email.Equals(usernameOrEmail) || x.UserName.Equals(usernameOrEmail));

            ExceptionHelper.NullCheck<User>(user, ApplicationConsts.ExceptionMessages.UserIsNull);

            return user;
        }

        public async Task CreateAsync(User user)
        {
            await userManager.CreateAsync(user, user.PasswordHash);
        }

        public async Task UpdateAsync(User user)
        {
            await userRepository.Update(user);
        }

        public async Task DeleteAsync(string id)
        {
            User user = new User
            {
                Id = id
            };

            await userRepository.Delete(user);
        }
    }
}
