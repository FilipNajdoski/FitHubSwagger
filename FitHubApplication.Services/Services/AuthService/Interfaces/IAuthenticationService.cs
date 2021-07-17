using FitHubApplication.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IAuthenticationService
    {
        Task<SignInResult> LoginAsync(User user, string password);

        Task LogoutAsync();
    }
}
