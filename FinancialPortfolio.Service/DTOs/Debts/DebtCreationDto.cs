using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.DTOs.Debts;

public class DebtCreationDto
{
    public decimal Amount { get; set; }

    public long LenderUserId { get; set; }
    public long BorrowUserId { get; set; }
}
