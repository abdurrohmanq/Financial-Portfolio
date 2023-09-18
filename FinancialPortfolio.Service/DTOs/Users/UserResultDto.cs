using FinancialPortfolio.Domain.Enums;
using FinancialPortfolio.Service.DTOs.Attachments;

namespace FinancialPortfolio.Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public AttachmentResultDto Attachment { get; set; }
}
