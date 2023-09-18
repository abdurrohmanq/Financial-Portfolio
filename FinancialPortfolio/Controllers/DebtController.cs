using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Models;
using FinancialPortfolio.Service.DTOs.Debts;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Controllers;

public class DebtController : BaseController
{
    private readonly IDebtService debtService;
    public DebtController(IDebtService debtService)
    {
        this.debtService = debtService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(DebtCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await debtService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await debtService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(DebtUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await debtService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await debtService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await debtService.GetAllAsync(@params)
        });
}
