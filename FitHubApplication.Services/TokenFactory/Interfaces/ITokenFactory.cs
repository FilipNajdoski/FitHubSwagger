using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FitHubApplication.Services.TokenFactory
{
    public interface ITokenFactory
    {
        void CreateAccessToken(List<Claim> claims, out JwtSecurityToken jwtSecurityToken, out string accessToken);
    }
}
