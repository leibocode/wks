using Microsoft.AspNetCore.Mvc;

namespace WKS_API.Controllers
{
    [ApiController]
    [Route("")]
    public class HealthController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
