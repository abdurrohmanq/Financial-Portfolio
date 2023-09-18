using FinancialPortfolio.Domain.Entities.Attachments;
using FinancialPortfolio.Service.DTOs.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(Attachment attachment);
}
