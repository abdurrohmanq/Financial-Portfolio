using AutoMapper;
using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Domain.Enums;
using FinancialPortfolio.Service.DTOs.Attachments;
using FinancialPortfolio.Service.DTOs.Users;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Helpers;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private readonly IAttachmentService attachmentService;
    private readonly IMapper mapper;
    public UserService(IRepository<User> repository, IMapper mapper, IAttachmentService attachmentService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.attachmentService = attachmentService;
    }
    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var user = await repository.GetAsync(u => u.Phone.Equals(dto.Phone));
        if (user is not null)
            throw new AlreadyExistException($"This user already exist with phone = {dto.Phone}");

        var mappedUser = mapper.Map<User>(dto);
        mappedUser.Password = PasswordHash.Encrypt(mappedUser.Password);
        await repository.CreateAsync(mappedUser);
        await repository.SaveChanges();

        return mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This user not found with phone = {id}");

        repository.Delete(user);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync(PaginationParams @params)
    {
        var users = await repository.GetAll().ToPaginate(@params).ToListAsync();
        return mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<UserResultDto> GetAsync(long id)
    {
        var user = await repository.GetAsync(u => u.Id.Equals(id))
           ?? throw new NotFoundException($"This user not found with phone = {id}");

        var result = mapper.Map<UserResultDto>(user);
        return result;
    }


    public async Task<UserResultDto> UpdateAsync(UserUpdateDto dto)
    {
        var user = await repository.GetAsync(u => u.Id.Equals(dto.Id))
           ?? throw new NotFoundException($"This user not found with phone = {dto.Id}");

        mapper.Map(dto, user);
        user.Password = PasswordHash.Encrypt(dto.Password);
        repository.Update(user);
        await repository.SaveChanges();

        return mapper.Map<UserResultDto>(user);
    }

    public async Task<UserResultDto> UpgradeRoleAsync(long userId, UserRole role)
    {
        var existUser = await repository.GetAsync(u => u.Id.Equals(userId))
            ?? throw new NotFoundException("This user is not found");

        existUser.Role = role;
        await repository.SaveChanges();

        return mapper.Map<UserResultDto>(existUser);
    }

    public async Task<UserResultDto> UploadImageAsync(long userId, AttachmentCreationDto dto)
    {
        var existUser = await repository.GetAsync(u => u.Id.Equals(userId))
               ?? throw new NotFoundException("This user is not found");

        var createdAttachment = await attachmentService.UploadAsync(dto);
        existUser.Attachment = createdAttachment;
        await repository.SaveChanges();

        return mapper.Map<UserResultDto>(existUser);
    }
    public async Task<UserResultDto> ModifyImageAsync(long userId, AttachmentCreationDto dto)
    {
        var existUser = await repository.GetAsync(u => u.Id.Equals(userId),includes: new[] {"Attachment"})
              ?? throw new NotFoundException("This user is not found");

        await attachmentService.RemoveAsync(existUser.Attachment);
        var createdAttachment = await attachmentService.UploadAsync(dto);
        existUser.Attachment = createdAttachment;
        repository.Update(existUser);
        await repository.SaveChanges();

        return mapper.Map<UserResultDto>(existUser);
    }
}
