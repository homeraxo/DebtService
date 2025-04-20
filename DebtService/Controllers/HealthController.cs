using Microsoft.AspNetCore.Mvc;

namespace DebtService.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "Servicio corriendo" });
        }
    }
}
