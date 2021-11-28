using FitHubApplication.Models.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitHubApplication.Services.TokenFactory
{
    public class TokenFactory : ITokenFactory
    {
        private readonly JwtSettings jwtSettings;

        public TokenFactory(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public void CreateAccessToken(List<Claim> claims, out JwtSecurityToken jwtSecurityToken, out string accessToken)
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
    }
}
