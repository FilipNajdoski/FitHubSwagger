using FitHubApplication.Models;
using FitHubApplication.Models.Entities;

namespace FitHubApplication.Repositories
{
    public class EventRepository : FitHubBaseRepository<Event>, IEventRepository
    {
        public EventRepository(FitHubDbContext context) : base(context)
        {
        }
    }
}
