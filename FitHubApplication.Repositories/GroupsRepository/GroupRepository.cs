using FitHubApplication.Models;
using FitHubApplication.Models.Entities;

namespace FitHubApplication.Repositories
{
    public class GroupRepository : FitHubBaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(FitHubDbContext context) : base(context)
        {
        }
    }
}
