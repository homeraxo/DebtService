namespace DebtService.DTOs
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
