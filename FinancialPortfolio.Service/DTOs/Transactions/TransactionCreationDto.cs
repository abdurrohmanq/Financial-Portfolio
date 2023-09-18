using FinancialPortfolio.Service.DTOs.Transactions.TransactionTypes;

namespace FinancialPortfolio.Service.DTOs.Transactions;

public class TransactionCreationDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public TransactionTypeCreationDto Type { get; set; }
    public long UserId { get; set; }
}
