using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}
