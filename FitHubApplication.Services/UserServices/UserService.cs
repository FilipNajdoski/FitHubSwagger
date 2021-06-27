using FitHubApplication.Models;
using FitHubApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await userRepository.GetAll().ToListAsync();
        }

        public async Task<List<User>> GetByName(string name)
        {
            return await userRepository.GetWhere(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await userRepository.GetFirstWhere(x => x.Id.Equals(id));
        }

        public async Task CreateAsync(User user)
        {
            await userRepository.Create(user);
        }

        public async Task UpdateAsync(User user)
        {
            await userRepository.Update(user);
        }

        public async Task DeleteAsync(int id)
        {
            User user = new User
            {
                Id = id
            };

            await userRepository.Delete(user);
        }
    }
}
