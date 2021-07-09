using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services;
using FitHubApplication.Services.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration configuration;

        public AuthController(IAuthenticationService authenticationService, IUserService  userService, IConfiguration configuration)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.configuration = configuration;
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

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[ApplicationConsts.ConfigConsts.JwtSecurityKey]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration[ApplicationConsts.ConfigConsts.JwtIssuer],
                audience: configuration[ApplicationConsts.ConfigConsts.JwtAudience],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            AuthenticationModel authenticationModel = new AuthenticationModel
            {
                AccessToken = accessToken,
                ExpirationTime = jwtSecurityToken.ValidTo,
                EncryptedAccessToken = accessToken,
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
