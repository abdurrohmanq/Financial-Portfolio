using FinancialPortfolio.Domain.Commons;
using FinancialPortfolio.Domain.Entities.Assets;
using FinancialPortfolio.Domain.Entities.Attachments;
using FinancialPortfolio.Domain.Entities.Debts;
using FinancialPortfolio.Domain.Entities.Incomes;
using FinancialPortfolio.Domain.Entities.Taxes;
using FinancialPortfolio.Domain.Entities.Transactions;
using FinancialPortfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinancialPortfolio.Domain.Entities.Users;

public class User : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
    public UserRole Role { get; set; }

    [JsonIgnore]
    public ICollection<Asset> Assets { get; set; }
    [JsonIgnore]
    public ICollection<Debt> DebtsTaken { get; set; }
    [JsonIgnore]
    public ICollection<Debt> DebtsGiven { get; set; }
    [JsonIgnore]
    public ICollection<Income> Incomes { get; set; }
    [JsonIgnore]
    public ICollection<Tax> Taxes { get; set; }
    [JsonIgnore]
    public ICollection<Transaction> Transactions { get; set; }
}
