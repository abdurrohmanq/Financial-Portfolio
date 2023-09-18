using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.DTOs.Assets;

public class AssetCreationDto
{
    public string Name { get; set; }

    public decimal Value { get; set; }

    public long UserId { get; set; }
}
