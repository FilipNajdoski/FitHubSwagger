using FitHubApplication.Models.Entities;

namespace FitHubApplication.Services.Mapper
{
    public static class EventMapper
    {

        /// <summary>
        /// Converts from <see cref="Event"/> to <see cref="EventDto"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EventDto EntityToDto(this Event entity)
        {
            return new EventDto
            {
                Id = entity.Id,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                GroupId = entity.GroupId,
                Name = entity.Name,
                Group = entity.Group.EntityToDto(),
            };
        }

        /// <summary>
        /// Converts from <see cref="CreateEventDto"/> to <see cref="Event"/>
        /// </summary>
        /// <param name="createEventDto"></param>
        /// <returns></returns>
        public static Event CreateDtoToEntity(this CreateEventDto createEventDto)
        {
            return new Event
            {
                Name = createEventDto.Name,
                StartDate = createEventDto.StartDate,
                EndDate = createEventDto.EndDate,
                GroupId = createEventDto.GroupId,
            };
        }

        /// <summary>
        /// Converts from <see cref="EventDto"/> to <see cref="Event"/>
        /// </summary>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        public static Event DtoToEntity(this EventDto eventDto)
        {
            return new Event
            {
                Id = eventDto.Id,
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
                GroupId = eventDto.GroupId,
                Name = eventDto.Name,
                Group = eventDto.Group.DtoToEntity(),
            };
        }
    }
}
