using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FitHubApplication.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// this will get the user
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public ActionResult<string> GetUser()
        {
            try
            {
                throw new Exception("try ex");
            }
            catch (Exception ex)
            {

            throw new Exception(ex.ToString());
              
            }


            return Ok("user ok");
        }
    }
}
