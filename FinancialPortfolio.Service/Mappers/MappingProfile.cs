using AutoMapper;
using FinancialPortfolio.Domain.Entities.Assets;
using FinancialPortfolio.Domain.Entities.Attachments;
using FinancialPortfolio.Domain.Entities.Debts;
using FinancialPortfolio.Domain.Entities.Incomes;
using FinancialPortfolio.Domain.Entities.Taxes;
using FinancialPortfolio.Domain.Entities.Transactions;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Service.DTOs.Assets;
using FinancialPortfolio.Service.DTOs.Attachments;
using FinancialPortfolio.Service.DTOs.Debts;
using FinancialPortfolio.Service.DTOs.Incomes;
using FinancialPortfolio.Service.DTOs.Incomes.IncomeTypes;
using FinancialPortfolio.Service.DTOs.Taxes;
using FinancialPortfolio.Service.DTOs.Transactions;
using FinancialPortfolio.Service.DTOs.Transactions.TransactionTypes;
using FinancialPortfolio.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //For user
        CreateMap<User,UserResultDto>().ReverseMap();
        CreateMap<UserUpdateDto,User>().ReverseMap();
        CreateMap<User,UserCreationDto>().ReverseMap();

        CreateMap<Tax, TaxResultDto>().ReverseMap();
        CreateMap<TaxUpdateDto, Tax>().ReverseMap();
        CreateMap<Tax, TaxCreationDto>().ReverseMap();

        CreateMap<Asset,AssetResultDto>().ReverseMap();
        CreateMap<AssetUpdateDto, Asset>().ReverseMap();
        CreateMap<Asset, AssetCreationDto>().ReverseMap();

        CreateMap<Debt, DebtResultDto>().ReverseMap();
        CreateMap<DebtUpdateDto, Debt>().ReverseMap();
        CreateMap<Debt, DebtCreationDto>().ReverseMap();

        CreateMap<Income, IncomeResultDto>().ReverseMap();
        CreateMap<IncomeUpdateDto, Income>().ReverseMap();
        CreateMap<Income, IncomeCreationDto>().ReverseMap();

        CreateMap<IncomeType, IncomeTypeResultDto>().ReverseMap();
        CreateMap<IncomeTypeUpdateDto, IncomeType>().ReverseMap();
        CreateMap<IncomeType, IncomeTypeCreationDto>().ReverseMap();

        CreateMap<Transaction, TransactionResultDto>().ReverseMap();
        CreateMap<TransactionUpdateDto, Transaction>().ReverseMap();
        CreateMap<Transaction, TransactionCreationDto>().ReverseMap();

        CreateMap<TransactionType, TransactionTypeResultDto>().ReverseMap();
        CreateMap<TransactionTypeUpdateDto, TransactionType>().ReverseMap();
        CreateMap<TransactionType, TransactionTypeCreationDto>().ReverseMap();

        // Attachment
        CreateMap<AttachmentResultDto, Attachment>().ReverseMap();
    }
}
