using Microsoft.EntityFrameworkCore;

namespace FitHubApplication.Models
{
    public class FitHubDbContext : DbContext
    {
        public FitHubDbContext( DbContextOptions<FitHubDbContext> options) : base (options){}

        public DbSet<User> Users { get; set; }

    }
}
