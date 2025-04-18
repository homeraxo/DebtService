using System.ComponentModel.DataAnnotations.Schema;

namespace DebtService.Models
{
    public class Transaction
    {
        [Column("transaction_id")]
        public int TransactionId { get; set; }
        [Column("wallet_id")]
        public int WalletId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("transaction_date")]
        public DateTime TransactionDate { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Wallet Wallet { get; set; }
    }
}
