using DebtService.DTOs;

namespace DebtService.Services
{
    public interface IWalletService
    {
        Task<WalletDto?> GetWalletByEmailAsync(string email);
        Task<decimal?> GetCurrentBalanceByEmailAsync(string email);
        Task<List<TransactionDto>> GetTransactionHistoryAsync(string email);
    }
}
