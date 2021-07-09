using FitHubApplication.Models.Constants;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitHubApplication.Controllers
{
    [EnableCors(ApplicationConsts.CorsConsts.CorsPolicy)]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route(ApplicationConsts.ControllerConsts.HomeControllerRoute)]
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

            return new RedirectResult(ApplicationConsts.SwaggerConsts.SwaggerRedirection);
        }
    }
}
