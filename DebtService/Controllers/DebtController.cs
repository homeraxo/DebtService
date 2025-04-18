using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DebtService.Services;
using System.Security.Claims;

namespace DebtService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("debt-indicators")]
    public class DebtController : ControllerBase
    {
        private readonly IDebtAnalysisService _debtService;

        public DebtController(IDebtAnalysisService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDebtIndicators()
        {
            var claimValue = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault()?.Value;

            var email = claimValue;//User.Identity?.Name ?? User.FindFirst("email")?.Value;
            var indicators = await _debtService.GetDebtIndicatorsAsync(email!);

            if (indicators == null)
                return NotFound("No hay historial de deuda");

            return Ok(indicators);
        }
    }
}
