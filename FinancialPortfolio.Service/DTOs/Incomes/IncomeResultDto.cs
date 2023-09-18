using FinancialPortfolio.Service.DTOs.Incomes.IncomeTypes;
using FinancialPortfolio.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.DTOs.Incomes;

public class IncomeResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }

    public IncomeTypeResultDto Type { get; set; }
    public UserResultDto User { get; set; }
}
