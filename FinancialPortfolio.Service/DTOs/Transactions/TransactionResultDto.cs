using FinancialPortfolio.Service.DTOs.Transactions.TransactionTypes;
using FinancialPortfolio.Service.DTOs.Users;

namespace FinancialPortfolio.Service.DTOs.Transactions;

public class TransactionResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public TransactionTypeResultDto Type { get; set; }
    public UserResultDto User { get; set; }
}
