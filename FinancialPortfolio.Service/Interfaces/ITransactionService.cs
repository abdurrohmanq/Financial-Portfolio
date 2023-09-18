using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Service.DTOs.Transactions;

namespace FinancialPortfolio.Service.Interfaces;

public interface ITransactionService
{
    Task<TransactionResultDto> AddAsync(TransactionCreationDto dto);
    Task<TransactionResultDto> UpdateAsync(TransactionUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<TransactionResultDto> GetAsync(long id);
    Task<IEnumerable<TransactionResultDto>> GetAllAsync(PaginationParams @params);
}
