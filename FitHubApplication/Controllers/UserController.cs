using FitHubApplication.Helpers;
using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services;
using FitHubApplication.Services.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Controllers
{
    [EnableCors(ApplicationConsts.CorsConsts.CorsPolicy)]
    [Route(ApplicationConsts.ControllerConsts.DefaultControllerRoute)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Returns user with given ID 
        /// </summary>
        /// <param name="id"> this is the specified userID</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            ExceptionHelper.StringIsEmpty(id, ApplicationConsts.ExceptionMessages.StingIsEmpty);

            UserDto user = await userService.GetById(id);

            return Ok(user);
        }

        /// <summary>
        /// Searches a user for all given inputs
        /// </summary>
        /// <param name="searchInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<UserDto>>> Search(UserSearchInput searchInput)
        {
            ExceptionHelper.NullCheck<UserSearchInput>(searchInput, ApplicationConsts.ExceptionMessages.SearchIsNull);

            List<UserDto> users = await userService.Search(searchInput);

            return Ok(users);
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> CreateUser(RegisetUserViewModel user)
        {

            ExceptionHelper.NullCheck<RegisetUserViewModel>(user, ApplicationConsts.ExceptionMessages.UserIsNull);

            await userService.CreateAsync(user.User, user.PlainPassword);

            return Ok("user successfully created");
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> UpdateUser(UserDto user)
        {
            ExceptionHelper.NullCheck<UserDto>(user, ApplicationConsts.ExceptionMessages.UserIsNull);

            await userService.UpdateAsync(user);

            return Ok("user successfully updated");
        }
        
        /// <summary>
        /// Deletes a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> DeleteUser(string id)
        {
            ExceptionHelper.StringIsEmpty(id, ApplicationConsts.ExceptionMessages.StingIsEmpty);

            await userService.DeleteAsync(id);

            return Ok("user successfully deleted");
        }
    }
}
