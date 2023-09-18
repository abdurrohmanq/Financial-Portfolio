using FinancialPortfolio.Service.DTOs.Users;

namespace FinancialPortfolio.Service.DTOs.Taxes;

public class TaxResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public int Year { get; set; }

    public UserResultDto User { get; set; }
}
