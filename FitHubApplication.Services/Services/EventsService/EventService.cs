using FitHubApplication.Models.Entities;
using FitHubApplication.Repositories;
using FitHubApplication.Services.Extensions;
using FitHubApplication.Services.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<List<EventDto>> Search(EventSearchInput input)
        {
            IQueryable<Event> query = eventRepository.GetAll()
                .Include(x => x.Group)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Name), x => x.Name.Equals(input.Name))
                .WhereIf(input.StartDate.HasValue, x => x.StartDate >= input.StartDate.Value)
                .WhereIf(input.EndDate.HasValue, x => x.EndDate <= input.EndDate.Value)
                .WhereIf(input.StartDate.HasValue && input.EndDate.HasValue, x => x.StartDate >= input.StartDate.Value && x.EndDate <= input.EndDate.Value);

            List<EventDto> events = await query
                .Skip(input.SkipCount)
                .Take(input.TakeCount)
                .Select(x => x.EntityToDto())
                .ToListAsync();

            return events;
        }

        public async Task Create(CreateEventDto createEventDto)
        {
            await eventRepository.Create(createEventDto.CreateDtoToEntity());
        }

        public async Task Update(EventDto eventDto)
        {
            await eventRepository.Update(eventDto.DtoToEntity());
        }

        public async Task Delete(int eventId)
        {
            Event @event = new Event
            {
                Id = eventId,
            };

            await eventRepository.Delete(@event);
        }
    }
}
