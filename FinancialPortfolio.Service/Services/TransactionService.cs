using AutoMapper;
using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Entities.Transactions;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Service.DTOs.Transactions;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Service.Services;

public class TransactionService : ITransactionService
{
    private readonly IRepository<Transaction> repository;
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;
    public TransactionService(IRepository<Transaction> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<TransactionResultDto> AddAsync(TransactionCreationDto dto)
    {
        var user = await userRepository.GetAsync(u => u.Id.Equals(dto.UserId));
        if (user is null)
            throw new NotFoundException($"This user not found");

        var mappedTransaction = mapper.Map<Transaction>(dto);
        mappedTransaction.User = user;
        await repository.CreateAsync(mappedTransaction);
        await repository.SaveChanges();

        return mapper.Map<TransactionResultDto>(mappedTransaction);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existTransaction = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Transaction not found with id = {id}");

        repository.Delete(existTransaction);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<TransactionResultDto>> GetAllAsync(PaginationParams @params)
    {
        var allTransactions = await repository.GetAll(includes: new[] { "Type", "User" }).ToPaginate(@params).ToListAsync();
        return mapper.Map<IEnumerable<TransactionResultDto>>(allTransactions);
    }

    public async Task<TransactionResultDto> GetAsync(long id)
    {
        var existTransaction = await repository.GetAsync(u => u.Id.Equals(id), includes: new[] { "Type", "User" })
           ?? throw new NotFoundException($"This Transaction not found with id = {id}");

        var result = mapper.Map<TransactionResultDto>(existTransaction);
        return result;
    }

    public async Task<TransactionResultDto> UpdateAsync(TransactionUpdateDto dto)
    {
        var existTransaction = await repository.GetAsync(u => u.Id.Equals(dto.Id))
           ?? throw new NotFoundException($"This Transaction not found with id = {dto.Id}");

        mapper.Map(dto, existTransaction);
        repository.Update(existTransaction);
        await repository.SaveChanges();

        return mapper.Map<TransactionResultDto>(existTransaction);
    }
}