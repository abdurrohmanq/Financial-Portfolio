using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Configurations;

public class PaginationParams
{
    public int PageIndex { get; set; } = 1;
    private const int maxSize = 20;
    private int pageSize;
    public int PageSize
    { 
        get => pageSize == 0 ? maxSize : pageSize;
        set { pageSize = value > maxSize ? maxSize : value; }
    }
}
