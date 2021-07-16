using FitHubApplication.Models.Entities;
using System.Collections.Generic;
using System.Security.Claims;
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

        Task<User> Get(string usernameOrEmail);

        Task<IList<Claim>> GetClaimsAsync(User user);
    }
}
