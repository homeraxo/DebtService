using System.ComponentModel.DataAnnotations.Schema;

namespace DebtService.Models
{
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("fullname")]
        public string Fullname { get; set; } = null!;
        [Column("email")]
        public string Email { get; set; } = null!;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<VehicleLease> VehicleLeases { get; set; }
    }
}
