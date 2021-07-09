using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services;
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
        public async Task<ActionResult<User>> GetUser(string id)
        {

            User user = await userService.GetById(id);


            return Ok(user);
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {

            List<User> user = await userService.GetAllAsync();


            return Ok(user);
        }

        /// <summary>
        /// This will return a list of users with a given Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetByName(string name)
        {

            List<User> user = await userService.GetByName(name);


            return Ok(user);
        }

        /// <summary>
        /// This will create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CreateUser(User user)
        {

            await userService.CreateAsync(user);


            return Ok("user successfully created");
        }

        /// <summary>
        /// This will update the desired user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<string>> UpdateUser(User user)
        {

            await userService.UpdateAsync(user);


            return Ok("user successfully updated");
        }
        
        /// <summary>
        /// This will delete the user with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteUser(string id)
        {

            await userService.DeleteAsync(id);


            return Ok("user successfully deleted");
        }
    }
}
