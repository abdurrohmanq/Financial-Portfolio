using AutoMapper;
using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Entities.Incomes;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Service.DTOs.Incomes;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Service.Services;

public class IncomeService : IIncomeService
{
    private readonly IRepository<Income> repository;
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;
    public IncomeService(IRepository<Income> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<IncomeResultDto> AddAsync(IncomeCreationDto dto)
    {
        var user = await userRepository.GetAsync(u => u.Id.Equals(dto.UserId));
        if (user is null)
            throw new NotFoundException($"This user not found");

        var mappedIncome = mapper.Map<Income>(dto);
        mappedIncome.User = user;
        await repository.CreateAsync(mappedIncome);
        await repository.SaveChanges();

        return mapper.Map<IncomeResultDto>(mappedIncome);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existIncome = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Income not found with id = {id}");

        repository.Delete(existIncome);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<IncomeResultDto>> GetAllAsync(PaginationParams @params)
    {
        var allIncomes = await repository.GetAll(includes: new[] {"Type","User"}).ToPaginate(@params).ToListAsync();
        return mapper.Map<IEnumerable<IncomeResultDto>>(allIncomes);
    }

    public async Task<IncomeResultDto> GetAsync(long id)
    {
        var existIncome = await repository.GetAsync(u => u.Id.Equals(id), includes: new[] { "Type", "User" })
           ?? throw new NotFoundException($"This Income not found with id = {id}");

        var result = mapper.Map<IncomeResultDto>(existIncome);
        return result;
    }

    public async Task<IncomeResultDto> UpdateAsync(IncomeUpdateDto dto)
    {
        var existIncome = await repository.GetAsync(u => u.Id.Equals(dto.Id))
           ?? throw new NotFoundException($"This Income not found with id = {dto.Id}");

        mapper.Map(dto, existIncome);
        repository.Update(existIncome);
        await repository.SaveChanges();

        return mapper.Map<IncomeResultDto>(existIncome);
    }
}