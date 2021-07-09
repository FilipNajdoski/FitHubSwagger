using FitHubApplication.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> signInManager;

        public AuthenticationService(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(User user, string password)
        {
            SignInResult signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);
            return signInResult;
        }
        
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
