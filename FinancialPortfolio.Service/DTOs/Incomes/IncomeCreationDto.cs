using FinancialPortfolio.Service.DTOs.Incomes.IncomeTypes;

namespace FinancialPortfolio.Service.DTOs.Incomes;

public class IncomeCreationDto
{
    public decimal Amount { get; set; }

    public IncomeTypeCreationDto Type { get; set; }
    public long UserId { get; set; }
}
