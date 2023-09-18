using FinancialPortfolio.Domain.Commons;
using FinancialPortfolio.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Entities.Debts;

public class Debt : AudiTable
{
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public long LenderUserId { get; set; }
    public User LenderUser { get; set; }
    public long BorrowUserId { get; set; }
    public User BorrowUser { get; set; }
}
