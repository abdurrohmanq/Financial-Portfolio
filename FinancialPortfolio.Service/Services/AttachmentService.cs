using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Entities.Attachments;
using FinancialPortfolio.Service.DTOs.Attachments;
using FinancialPortfolio.Service.Extensions;
using FinancialPortfolio.Service.Helpers;
using FinancialPortfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> repository;
    public AttachmentService(IRepository<Attachment> repository)
    {
        this.repository = repository;
    }
    public async Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, "Files");

        if(!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")} {fileExtension}";
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FilePath = fullPath,
        };

        await repository.CreateAsync(createdAttachment);
        await repository.SaveChanges();

        return createdAttachment;
    }
    public async Task<bool> RemoveAsync(Attachment attachment)
    {
        repository.Delete(attachment);
        await repository.SaveChanges();
        return true;
    }

}
