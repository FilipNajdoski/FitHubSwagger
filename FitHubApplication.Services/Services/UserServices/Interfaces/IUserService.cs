using FitHubApplication.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IUserService
    {
        Task<UserDto> GetById(string id);

        Task CreateAsync(CreateUserDto user, string plainPassword);

        Task UpdateAsync(UserDto user);

        Task DeleteAsync(string id);

        Task<User> Get(string usernameOrEmail);

        Task<List<UserDto>> Search(UserSearchInput input);
    }
}
