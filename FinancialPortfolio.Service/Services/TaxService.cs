using AutoMapper;
using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Entities.Taxes;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Service.DTOs.Taxes;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Service.Services;

public class TaxService : ITaxService
{
    private readonly IRepository<Tax> repository;
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;
    public TaxService(IRepository<Tax> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<TaxResultDto> AddAsync(TaxCreationDto dto)
    {
        var user = await userRepository.GetAsync(u => u.Id.Equals(dto.UserId));
        if (user is null)
            throw new NotFoundException($"This user not found");

        var mappedTax = mapper.Map<Tax>(dto);
        mappedTax.User = user;
        await repository.CreateAsync(mappedTax);
        await repository.SaveChanges();

        return mapper.Map<TaxResultDto>(mappedTax);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existTax = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Tax not found with id = {id}");

        repository.Delete(existTax);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<TaxResultDto>> GetAllAsync(PaginationParams @params)
    {
        var allTaxs = await repository.GetAll().ToPaginate(@params).ToListAsync();
        return mapper.Map<IEnumerable<TaxResultDto>>(allTaxs);
    }

    public async Task<TaxResultDto> GetAsync(long id)
    {
        var existTax = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Tax not found with id = {id}");

        var result = mapper.Map<TaxResultDto>(existTax);
        return result;
    }

    public async Task<TaxResultDto> UpdateAsync(TaxUpdateDto dto)
    {
        var existTax = await repository.GetAsync(u => u.Id.Equals(dto.Id))
           ?? throw new NotFoundException($"This Tax not found with id = {dto.Id}");

        mapper.Map(dto, existTax);
        repository.Update(existTax);
        await repository.SaveChanges();

        return mapper.Map<TaxResultDto>(existTax);
    }
}
