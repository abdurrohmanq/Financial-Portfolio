using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Models;
using FinancialPortfolio.Service.DTOs.Assets;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Controllers;

public class AssetController : BaseController
{
    private readonly IAssetService assetService;
    public AssetController(IAssetService assetService)
    {
        this.assetService = assetService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AssetCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AssetUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.GetAllAsync(@params)
        });
}
