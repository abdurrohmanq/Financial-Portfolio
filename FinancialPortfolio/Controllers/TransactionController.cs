using FinancialPortfolio.Domain.Configurations;
using FinancialPortfolio.Models;
using FinancialPortfolio.Service.DTOs.Transactions;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Controllers;

public class TransactionController : BaseController
{
    private readonly ITransactionService transactionService;
    public TransactionController(ITransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(TransactionCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await transactionService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await transactionService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(TransactionUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await transactionService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await transactionService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await transactionService.GetAllAsync(@params)
        });
}
