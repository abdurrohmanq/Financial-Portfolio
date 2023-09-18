using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(string phone, string password);
}
