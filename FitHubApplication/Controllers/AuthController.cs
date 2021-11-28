using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Models.Entities;
using FitHubApplication.Services;
using FitHubApplication.Services.ClaimFactory;
using FitHubApplication.Services.Exceptions;
using FitHubApplication.Services.TokenFactory;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace FitHubApplication.Controllers
{
    [EnableCors(ApplicationConsts.CorsConsts.CorsPolicy)]
    [Route(ApplicationConsts.ControllerConsts.DefaultControllerRoute)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;
        private readonly ITokenFactory tokenFactory;
        private readonly IClaimFactory claimFactory;

        public AuthController
            (
            IAuthenticationService authenticationService, 
            IUserService  userService, 
            ITokenFactory tokenFactory,
            IClaimFactory claimFactory
            )
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.tokenFactory = tokenFactory;
            this.claimFactory = claimFactory;
        }

        /// <summary>
        /// Logs in the user and creates a jwt token
        /// </summary>
        /// <param name="usernameOrEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuthenticationModel>> Authenticate(string usernameOrEmail, string password)
        {
            User user = await userService.Get(usernameOrEmail);

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await authenticationService.LoginAsync(user, password);

            ExceptionHelper.LoginFailed(signInResult.Succeeded, ApplicationConsts.ExceptionMessages.LoginFailed);

            tokenFactory.CreateAccessToken(claimFactory.CreateUserClaims(user), out JwtSecurityToken jwtSecurityToken, out string accessToken);

            AuthenticationModel authenticationModel = new AuthenticationModel
            {
                AccessToken = accessToken,
                ExpirationTime = jwtSecurityToken.ValidTo,
                EncryptedAccessToken = accessToken,//encrypt this to put it as cookie
            };

            return Ok(authenticationModel);
        }

        /// <summary>
        /// Logs out the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await authenticationService.LogoutAsync();
            return Ok();
        }
    }
}