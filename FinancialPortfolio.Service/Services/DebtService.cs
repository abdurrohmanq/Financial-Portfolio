using AutoMapper;
using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Entities.Debts;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Service.DTOs.Debts;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Service.Services;

public class DebtService : IDebtService
{
    private readonly IRepository<Debt> repository;
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;
    public DebtService(IRepository<Debt> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<DebtResultDto> AddAsync(DebtCreationDto dto)
    {
        var lenderUser = await userRepository.GetAsync(u => u.Id.Equals(dto.LenderUserId));
        var borrowUser = await userRepository.GetAsync(u => u.Id == dto.BorrowUserId);
        if (lenderUser is null || borrowUser is null)
            throw new NotFoundException($"This Lender user or borrow user not found");

        var mappedDebt = mapper.Map<Debt>(dto);
        mappedDebt.LenderUser = lenderUser;
        mappedDebt.BorrowUser = borrowUser;
        await repository.CreateAsync(mappedDebt);
        await repository.SaveChanges();

        return mapper.Map<DebtResultDto>(mappedDebt);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existDebt = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Debt not found with id = {id}");

        repository.Delete(existDebt);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<DebtResultDto>> GetAllAsync(PaginationParams @params)
    {
        var allDebts = await repository.GetAll().ToPaginate(@params).ToListAsync();
        return mapper.Map<IEnumerable<DebtResultDto>>(allDebts);
    }

    public async Task<DebtResultDto> GetAsync(long id)
    {
        var existDebt = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Debt not found with id = {id}");

        var result = mapper.Map<DebtResultDto>(existDebt);
        return result;
    }

    public async Task<DebtResultDto> UpdateAsync(DebtUpdateDto dto)
    {
        var existDebt = await repository.GetAsync(u => u.Id.Equals(dto.Id))
           ?? throw new NotFoundException($"This Debt not found with id = {dto.Id}");

        mapper.Map(dto, existDebt);
        repository.Update(existDebt);
        await repository.SaveChanges();

        return mapper.Map<DebtResultDto>(existDebt);
    }
}
