namespace FinancialPortfolio.Service.DTOs.Taxes;

public class TaxUpdateDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public int Year { get; set; }

    public long UserId { get; set; }
}
