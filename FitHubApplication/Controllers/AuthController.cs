using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitHubApplication.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

    }
}
