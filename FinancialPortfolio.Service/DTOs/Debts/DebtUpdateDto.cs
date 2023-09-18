namespace FinancialPortfolio.Service.DTOs.Debts;

public class DebtUpdateDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }

    public long LenderUserId { get; set; }
    public long BorrowUserId { get; set; }
}
