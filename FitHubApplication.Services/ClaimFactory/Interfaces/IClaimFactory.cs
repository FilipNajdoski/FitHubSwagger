using FitHubApplication.Models.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace FitHubApplication.Services.ClaimFactory
{
    public interface IClaimFactory
    {
        List<Claim> CreateUserClaims(User user);
    }
}
