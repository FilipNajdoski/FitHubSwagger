using FitHubApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();

        Task<List<User>> GetByName(string name);

        Task<User> GetById(string id);

        Task CreateAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(string id);

    }
}
