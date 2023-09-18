using FinancialPortfolio.Service.DTOs.Incomes.IncomeTypes;

namespace FinancialPortfolio.Service.DTOs.Incomes;

public class IncomeUpdateDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }

    public IncomeTypeUpdateDto Type { get; set; }
    public long UserId { get; set; }
}
