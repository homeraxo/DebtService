using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DebtService.Services;
using System.Security.Claims;

namespace DebtService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("get-wallet-by-email")]
        public async Task<IActionResult> GetWallet()
        {

            var claimValue = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault()?.Value;
            var email = claimValue; //User.Identity?.Name ?? User.FindFirst("email")?.Value;
            var wallet = await _walletService.GetWalletByEmailAsync(email!);
            if (wallet == null)
                return NotFound("Billetera no encontrada");

            return Ok(wallet);
        }

        [HttpGet("get-current-balance")]
        public async Task<IActionResult> GetCurrentBalance()
        {
            var claimValue = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault()?.Value;
            var email = claimValue; //User.Identity?.Name ?? User.FindFirst("email")?.Value;
            var balance = await _walletService.GetCurrentBalanceByEmailAsync(email!);
            if (balance == null)
                return NotFound("Saldo no disponible");

            return Ok(new { balance });
        }

        [HttpGet("get-transaction-history")]
        public async Task<IActionResult> GetTransactionHistory()
        {
            var claimValue = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault()?.Value;
            var email = claimValue; //User.Identity?.Name ?? User.FindFirst("email")?.Value;
            var history = await _walletService.GetTransactionHistoryAsync(email!);
            return Ok(history);
        }
    }
}
