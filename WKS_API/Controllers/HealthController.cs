using Microsoft.AspNetCore.Mvc;

namespace WKS_API.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController:ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
