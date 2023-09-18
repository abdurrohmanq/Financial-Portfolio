using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Service.DTOs.Taxes;

namespace FinancialPortfolio.Service.Interfaces;

public interface ITaxService
{
    Task<TaxResultDto> AddAsync(TaxCreationDto dto);
    Task<TaxResultDto> UpdateAsync(TaxUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<TaxResultDto> GetAsync(long id);
    Task<IEnumerable<TaxResultDto>> GetAllAsync(PaginationParams @params);
}
