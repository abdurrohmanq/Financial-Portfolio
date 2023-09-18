using FinancialPortfolio.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Entities.Attachments;

public class Attachment : AudiTable
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
