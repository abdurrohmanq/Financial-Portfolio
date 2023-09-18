using FinancialPortfolio.Domain.Commons;
using FinancialPortfolio.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Entities.Assets;

public class Asset : AudiTable
{
    public string Name { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
