using DebtService.DTOs;

namespace DebtService.Services
{
    public interface IDebtAnalysisService
    {
        Task<DebtIndicatorDto?> GetDebtIndicatorsAsync(string email);
    }
}
