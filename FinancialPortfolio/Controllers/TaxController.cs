using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Models;
using FinancialPortfolio.Service.DTOs.Taxes;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Controllers;

public class TaxController : BaseController
{
    private readonly ITaxService taxService;
    public TaxController(ITaxService taxService)
    {
        this.taxService = taxService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(TaxCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await taxService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await taxService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(TaxUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await taxService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await taxService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await taxService.GetAllAsync(@params)
        });
}
