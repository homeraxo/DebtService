using System.ComponentModel.DataAnnotations.Schema;

namespace DebtService.Models
{
    public class VehicleLease
    {
        [Column("vehiclelease_id")]
        public int VehicleLeaseId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("vehicle_vin")]
        public string VehicleVin { get; set; } = null!;
        [Column("vehicle_model")]
        public string VehicleModel { get; set; } = null!;
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("weekly_payment")]
        public decimal WeeklyPayment { get; set; }
        [Column("status")]
        public string Status { get; set; } = null!;
        [Column("contract_number")]
        public string ContractNumber { get; set; } = null!;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}
