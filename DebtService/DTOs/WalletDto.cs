namespace DebtService.DTOs
{
    public class WalletDto
    {
        public int WalletId { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
