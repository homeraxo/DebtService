using Microsoft.EntityFrameworkCore;
using DebtService.Data;
using DebtService.DTOs;
using DebtService.Models;

namespace DebtService.Services
{
    public class WalletService : IWalletService
    {
        private readonly ApplicationDbContext _context;

        public WalletService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WalletDto?> GetWalletByEmailAsync(string email)
        {
            var wallet = await _context.Wallets
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.User.Email == email);

            if (wallet == null) return null;

            return new WalletDto
            {
                WalletId = wallet.WalletId,
                BalanceAmount = wallet.BalanceAmount,
                Status = wallet.Status,
                CreatedAt = wallet.CreatedAt
            };
        }

        public async Task<decimal?> GetCurrentBalanceByEmailAsync(string email)
        {
            var wallet = await _context.Wallets
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.User.Email == email);

            return wallet?.BalanceAmount;
        }

        public async Task<List<TransactionDto>> GetTransactionHistoryAsync(string email)
        {
            var wallet = await _context.Wallets
                .Include(w => w.User)
                .Include(w => w.Transactions)
                .FirstOrDefaultAsync(w => w.User.Email == email);

            if (wallet == null) return new List<TransactionDto>();

            return wallet.Transactions.Select(t => new TransactionDto
            {
                Amount = t.Amount,
                Description = t.Description,
                TransactionDate = t.TransactionDate
            }).ToList();
        }
    }
}
