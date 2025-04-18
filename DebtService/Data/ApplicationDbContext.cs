using Microsoft.EntityFrameworkCore;
using DebtService.Models;

namespace DebtService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DebtEvent> DebtEvents { get; set; }
        public DbSet<VehicleLease> VehicleLeases { get; set; }
    }
}
