using FinancialPortfolio.Service.DTOs.Transactions.TransactionTypes;

namespace FinancialPortfolio.Service.DTOs.Transactions;

public class TransactionUpdateDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public TransactionTypeUpdateDto Type { get; set; }
    public long UserId { get; set; }
}
