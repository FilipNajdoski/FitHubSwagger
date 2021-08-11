using FitHubApplication.Helpers;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services;
using FitHubApplication.Services.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Controllers
{
    [Route(ApplicationConsts.ControllerConsts.DefaultControllerRoute)]
    [EnableCors(PolicyName = ApplicationConsts.CorsConsts.CorsPolicy)]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        /// <summary>
        /// Returns a list of groups filtered by provided input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<EventDto>>> Search(EventSearchInput input)
        {
            ExceptionHelper.NullCheck<EventSearchInput>(input, ApplicationConsts.ExceptionMessages.SearchIsNull);

            List<EventDto> events = await eventService.Search(input);

            return Ok(events);
        }

        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="createEventDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateEventDto createEventDto)
        {
            ExceptionHelper.NullCheck<CreateEventDto>(createEventDto, ApplicationConsts.ExceptionMessages.InputIsNull);

            await eventService.Create(createEventDto);

            return Ok();
        }

        /// <summary>
        /// Updates an existing event
        /// </summary>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(EventDto eventDto)
        {
            ExceptionHelper.NullCheck<EventDto>(eventDto, ApplicationConsts.ExceptionMessages.InputIsNull);

            await eventService.Update(eventDto);

            return Ok();
        }

        /// <summary>
        /// Deletes an existing event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int eventId)
        {
            ExceptionHelper.NullCheck(eventId, ApplicationConsts.ExceptionMessages.InputIsNull);

            await eventService.Delete(eventId);

            return Ok();
        }
    }
}