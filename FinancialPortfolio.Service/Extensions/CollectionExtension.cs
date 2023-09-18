using FinancialPortfolio.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Extensions;

public static class CollectionExtension
{
    public static IQueryable<T> ToPaginate<T>(this IQueryable<T> values, PaginationParams @params)
    {
        var source = values.Skip((@params.PageIndex-1) * @params.PageSize).Take(@params.PageSize);
        return source;
    }
}
