using FitHubApplication.Models;
using FitHubApplication.Models.Entities;

namespace FitHubApplication.Repositories
{
    public class ExcerciseRepository : FitHubBaseRepository<Exercise>, IExcerciseRepository
    {
        public ExcerciseRepository(FitHubDbContext context) : base(context)
        {
        }
    }
}
