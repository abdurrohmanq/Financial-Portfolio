using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Service.DTOs.Debts;

namespace FinancialPortfolio.Service.Interfaces;

public interface IDebtService
{
    Task<DebtResultDto> AddAsync(DebtCreationDto dto);
    Task<DebtResultDto> UpdateAsync(DebtUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<DebtResultDto>  GetAsync(long id);
    Task<IEnumerable<DebtResultDto>>  GetAllAsync(PaginationParams @params);
}
