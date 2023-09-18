using FinancialPortfolio.Domain.Commons;
using FinancialPortfolio.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Entities.Incomes;

public class Income : AudiTable
{
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public long TypeId { get; set; }
    public IncomeType Type { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
