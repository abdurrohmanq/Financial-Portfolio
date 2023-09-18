using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Domain.Enums;
using FinancialPortfolio.Models;
using FinancialPortfolio.Service.DTOs.Attachments;
using FinancialPortfolio.Service.DTOs.Users;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinancialPortfolio.Controllers;

public class UserController : BaseController
{
    private readonly IUserService userService;
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetAsync(id)
        });

    [Authorize(Roles = "Admin")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetAllAsync(@params)
        });

    [HttpPatch("upgrade-role")]
    public async Task<IActionResult> UpgradeRoleAsync(long id, UserRole role)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.UpgradeRoleAsync(id, role)
        });

    [HttpPost("image-upload")]
    public async Task<IActionResult> ImageUploadAsync(long userId, [FromForm] AttachmentCreationDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.UploadImageAsync(userId, dto)
        });
    }

    [HttpPost("update-image")]
    public async Task<IActionResult> UpdateImageAsync(long productId, [FromForm] AttachmentCreationDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.userService.ModifyImageAsync(productId, dto)
       });
}
