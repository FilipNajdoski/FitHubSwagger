using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitHubApplication.Models
{
    public class FitHubDbContext : IdentityDbContext<User>
    {
        public FitHubDbContext( DbContextOptions<FitHubDbContext> options) : base (options){}

    }
}
