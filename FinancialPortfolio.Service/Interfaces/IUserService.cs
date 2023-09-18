using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Enums;
using FinancialPortfolio.Service.DTOs.Attachments;
using FinancialPortfolio.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> UpdateAsync(UserUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<UserResultDto>  GetAsync(long id);
    Task<IEnumerable<UserResultDto>>  GetAllAsync(PaginationParams @params);
    Task<UserResultDto> UpgradeRoleAsync(long userId, UserRole role);
    Task<UserResultDto> UploadImageAsync(long userId, AttachmentCreationDto dto);
    Task<UserResultDto>  ModifyImageAsync(long userId,AttachmentCreationDto dto);
}
