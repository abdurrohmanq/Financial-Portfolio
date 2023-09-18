using FinancialPortfolio.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Entities.Transactions;

public class TransactionType : AudiTable
{
    public string Name { get; set; }
}
