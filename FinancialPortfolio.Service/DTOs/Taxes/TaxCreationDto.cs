using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.DTOs.Taxes;

public class TaxCreationDto
{
    public decimal Amount { get; set; }
    public int Year { get; set; }

    public long UserId { get; set; }
}
