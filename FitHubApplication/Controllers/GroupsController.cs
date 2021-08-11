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
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        /// <summary>
        /// Returns a list of groups filtered by provided input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<GroupDto>>> Search(GroupSearchInput input)
        {
            ExceptionHelper.NullCheck<GroupSearchInput>(input, ApplicationConsts.ExceptionMessages.SearchIsNull);

            List<GroupDto> groups = await groupService.Search(input);

            return Ok(groups);
        }

        /// <summary>
        /// Creates a new group
        /// </summary>
        /// <param name="createGroupDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateGroupDto createGroupDto)
        {
            ExceptionHelper.NullCheck<CreateGroupDto>(createGroupDto, ApplicationConsts.ExceptionMessages.InputIsNull);

            await groupService.Create(createGroupDto);

            return Ok();
        }

        /// <summary>
        /// Deletes an existing group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int groupId)
        {
            ExceptionHelper.NullCheck(groupId, ApplicationConsts.ExceptionMessages.InputIsNull);

            await groupService.Delete(groupId);

            return Ok();
        }

        /// <summary>
        /// Updates an exsiting group
        /// </summary>
        /// <param name="groupDto"></param>
        /// <returns>Updated group</returns>
        [HttpPut]
        public async Task<ActionResult<GroupDto>> Update(GroupDto groupDto)
        {
            ExceptionHelper.NullCheck<GroupDto>(groupDto, ApplicationConsts.ExceptionMessages.InputIsNull);

            GroupDto group = await groupService.Update(groupDto);

            return Ok(group);
        }
    }
}