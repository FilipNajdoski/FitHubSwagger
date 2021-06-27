using FitHubApplication.Models;

namespace FitHubApplication.Repositories
{
    public class UserRepository : FitHubBaseRepository<User>, IUserRepository
    {
        public UserRepository(FitHubDbContext context) : base(context)
        {

        }

    }
}
