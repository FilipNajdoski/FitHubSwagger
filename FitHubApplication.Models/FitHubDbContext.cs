using FitHubApplication.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitHubApplication.Models
{
    public class FitHubDbContext : IdentityDbContext<User>
    {
        public FitHubDbContext( DbContextOptions<FitHubDbContext> options) : base (options){}

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<UserExercise> UserExercises { get; set; }
        public DbSet<UploadedFiles> UploadedFiles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
