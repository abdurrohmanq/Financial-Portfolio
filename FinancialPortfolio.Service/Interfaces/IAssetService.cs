using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Service.DTOs.Assets;

namespace FinancialPortfolio.Service.Interfaces;

public interface IAssetService
{
    Task<AssetResultDto> AddAsync(AssetCreationDto dto);
    Task<AssetResultDto> UpdateAsync(AssetUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<AssetResultDto>  GetAsync(long id);
    Task<IEnumerable<AssetResultDto>>  GetAllAsync(PaginationParams @params);
}
