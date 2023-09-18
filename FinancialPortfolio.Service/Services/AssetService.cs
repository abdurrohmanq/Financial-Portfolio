using AutoMapper;
using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Helpers;
using FinancialPortfolio.Service.Interfaces;
using FinancialPortfolio.Service.DTOs.Assets;
using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Entities.Assets;
using FinancialPortfolio.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Service.Services;

public class AssetService : IAssetService
{
    private readonly IMapper mapper;
    private readonly IRepository<Asset> repository;
    private readonly IRepository<User> userRepository;
    public AssetService(IMapper mapper, 
        IRepository<Asset> repository, 
        IRepository<User> userRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.userRepository = userRepository;
    }
    public async Task<AssetResultDto> AddAsync(AssetCreationDto dto)
    {
        var user = await userRepository.GetAsync(u => u.Id.Equals(dto.UserId));
        if (user is null)
            throw new NotFoundException($"This user not found with userID = {dto.UserId}");

        var mappedAsset = mapper.Map<Asset>(dto);
        mappedAsset.User = user;
        await repository.CreateAsync(mappedAsset);
        await repository.SaveChanges();

        return mapper.Map<AssetResultDto>(mappedAsset);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existAsset = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This Asset not found with id = {id}");

        repository.Delete(existAsset);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<AssetResultDto>> GetAllAsync(PaginationParams @params)
    {
        var allAssets = await repository.GetAll(includes: new[] {"User"}).ToPaginate(@params).ToListAsync();
        return mapper.Map<IEnumerable<AssetResultDto>>(allAssets);
    }

    public async Task<AssetResultDto> GetAsync(long id)
    {
        var existAsset = await repository.GetAsync(u => u.Id.Equals(id), includes: new[] { "User" })
           ?? throw new NotFoundException($"This Asset not found with id = {id}");

        var result = mapper.Map<AssetResultDto>(existAsset);
        return result;
    }

    public async Task<AssetResultDto> UpdateAsync(AssetUpdateDto dto)
    {
        var existAsset = await repository.GetAsync(u => u.Id.Equals(dto.Id),includes: new[] {"User"})
           ?? throw new NotFoundException($"This Asset not found with id = {dto.Id}");

        mapper.Map(dto, existAsset);
        repository.Update(existAsset);
        await repository.SaveChanges();

        return mapper.Map<AssetResultDto>(existAsset);
    }
}
