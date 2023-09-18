using FinancialPortfolio.Service.DTOs.Users;

namespace FinancialPortfolio.Service.DTOs.Assets;

public class AssetResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }

    public decimal Value { get; set; }

    public UserResultDto User { get; set; }
}
