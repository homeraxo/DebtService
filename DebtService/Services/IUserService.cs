using DebtService.Models;

namespace DebtService.Services
{
    public interface IUserService
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
