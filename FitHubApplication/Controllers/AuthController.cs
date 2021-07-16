using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Models.Entities;
using FitHubApplication.Models.Utilities;
using FitHubApplication.Services;
using FitHubApplication.Services.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        private readonly JwtSettings jwtSettings;

        public AuthController(IAuthenticationService authenticationService, IUserService  userService, JwtSettings jwtSettings)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.jwtSettings = jwtSettings;
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

            CreateJwtToken(CreateUserClaims(user), out JwtSecurityToken jwtSecurityToken, out string accessToken);

            AuthenticationModel authenticationModel = new AuthenticationModel
            {
                AccessToken = accessToken,
                ExpirationTime = jwtSecurityToken.ValidTo,
                EncryptedAccessToken = accessToken,
            };

            return Ok(authenticationModel);
        }

        private void CreateJwtToken(List<Claim> claims,  out JwtSecurityToken jwtSecurityToken, out string accessToken)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey));

            jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static List<Claim> CreateUserClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
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