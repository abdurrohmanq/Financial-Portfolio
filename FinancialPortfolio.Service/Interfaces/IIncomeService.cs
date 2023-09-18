using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Service.DTOs.Incomes;

namespace FinancialPortfolio.Service.Interfaces;

public interface IIncomeService
{
    Task<IncomeResultDto> AddAsync(IncomeCreationDto dto);
    Task<IncomeResultDto> UpdateAsync(IncomeUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IncomeResultDto>  GetAsync(long id);
    Task<IEnumerable<IncomeResultDto>>  GetAllAsync(PaginationParams @params);
}
