using FitHubApplication.Models;
using FitHubApplication.Models.Entities;

namespace FitHubApplication.Repositories
{
    public class GroupTraineeRepository : FitHubBaseRepository<GroupTrainee>, IGroupTraineeRepository
    {
        public GroupTraineeRepository(FitHubDbContext context) : base(context)
        {
        }
    }
}
