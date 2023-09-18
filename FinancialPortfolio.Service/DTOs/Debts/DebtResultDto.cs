using FinancialPortfolio.Service.DTOs.Users;

namespace FinancialPortfolio.Service.DTOs.Debts;

public class DebtResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }

    public UserResultDto LenderUser { get; set; }
    public UserResultDto BorrowUser { get; set; }
}
