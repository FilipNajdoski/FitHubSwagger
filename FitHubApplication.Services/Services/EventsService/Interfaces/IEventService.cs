using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IEventService
    {
        Task<List<EventDto>> Search(EventSearchInput input);

        Task Create(CreateEventDto createEventDto);

        Task Update(EventDto eventDto);

        Task Delete(int eventId);
    }
}
