using Microsoft.EntityFrameworkCore;
using DebtService.Data;
using DebtService.Models;

namespace DebtService.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Wallets)
                .ThenInclude(w => w.Transactions)
                .Include(u => u.Wallets)
                .ThenInclude(w => w.DebtEvents)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
