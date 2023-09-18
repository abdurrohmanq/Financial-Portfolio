namespace FinancialPortfolio.Service.DTOs.Assets;

public class AssetUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }

    public decimal Value { get; set; }

    public long UserId { get; set; }
}
