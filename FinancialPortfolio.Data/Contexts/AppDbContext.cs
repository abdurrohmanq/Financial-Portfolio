using FinancialPortfolio.Domain.Entities.Assets;
using FinancialPortfolio.Domain.Entities.Debts;
using FinancialPortfolio.Domain.Entities.Incomes;
using FinancialPortfolio.Domain.Entities.Taxes;
using FinancialPortfolio.Domain.Entities.Transactions;
using FinancialPortfolio.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<IncomeType> IncomeTypes { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Asset>()
            .HasOne(u => u.User)
            .WithMany(u => u.Assets)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Debt>()
            .HasOne(u => u.LenderUser)
            .WithMany(d => d.DebtsGiven)
            .HasForeignKey(u => u.LenderUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Debt>()
            .HasOne(u => u.BorrowUser)
            .WithMany(d => d.DebtsTaken)
            .HasForeignKey(u => u.BorrowUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Income>()
            .HasOne(u => u.User)
            .WithMany(i => i.Incomes)
            .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tax>()
            .HasOne(u => u.User)
            .WithMany(t => t.Taxes)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Transaction>()
           .HasOne(u => u.User)
           .WithMany(t => t.Transactions)
           .HasForeignKey(u => u.UserId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
