using System.ComponentModel.DataAnnotations.Schema;

namespace DebtService.Models
{
    public class DebtEvent
    {
        [Column("debtevent_id")]
        public int DebtEventId { get; set; }
        [Column("wallet_id")]
        public int WalletId { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("duration_hours")]
        public int DurationHours { get; set; }
        [Column("settled")]
        public bool Settled { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Wallet Wallet { get; set; }
    }
}
