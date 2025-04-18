using System.ComponentModel.DataAnnotations.Schema;

namespace DebtService.Models
{
    public class Wallet
    {
        [Column("wallet_id")]
        public int WalletId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("lease_id")]
        public int LeaseId { get; set; }
        [Column("balance_amount")]
        public decimal BalanceAmount { get; set; }
        [Column("status")]
        public string Status { get; set; } = null!;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public VehicleLease Lease { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<DebtEvent> DebtEvents { get; set; }
    }
}
