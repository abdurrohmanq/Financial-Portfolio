using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Models;
using FinancialPortfolio.Service.DTOs.Incomes;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Controllers;

public class IncomeController : BaseController
{
    private readonly IIncomeService incomeService;
    public IncomeController(IIncomeService incomeService)
    {
        this.incomeService = incomeService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(IncomeCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await incomeService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await incomeService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(IncomeUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await incomeService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await incomeService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await incomeService.GetAllAsync(@params)
        });
}
