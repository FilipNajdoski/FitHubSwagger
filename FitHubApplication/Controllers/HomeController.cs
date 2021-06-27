using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitHubApplication.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// swagger redirection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Home()
        {

            return new RedirectResult("~/swagger");
        }
    }
}
