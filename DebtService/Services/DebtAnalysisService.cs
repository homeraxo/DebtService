using Microsoft.EntityFrameworkCore;
using DebtService.Data;
using DebtService.DTOs;
using System.Linq;

namespace DebtService.Services
{
    public class DebtAnalysisService : IDebtAnalysisService
    {
        private readonly ApplicationDbContext _context;

        public DebtAnalysisService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DebtIndicatorDto?> GetDebtIndicatorsAsync(string email)
        {
            var wallet = await _context.Wallets
                .Include(w => w.User)
                .Include(w => w.DebtEvents)
                .FirstOrDefaultAsync(w => w.User.Email == email);

            if (wallet == null || wallet.DebtEvents.Count == 0)
                return null;
            // get the total number of debt events and the average hours to settle
            int totalEvents = wallet.DebtEvents.Count;
            double averageHours = wallet.DebtEvents.Average(d => d.DurationHours);

            return new DebtIndicatorDto
            {
                TotalDebtEvents = totalEvents,
                AverageHoursToSettle = Math.Round(averageHours, 2)
            };
        }
    }
}
