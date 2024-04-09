using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public partial class Bootcampp2Context : DbContext
{
    public Bootcampp2Context()
    {
    }

    public Bootcampp2Context(DbContextOptions<Bootcampp2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Accounts> Accounts { get; set; }

    public virtual DbSet<Banks> Banks { get; set; }

    public virtual DbSet<Currency> Currency { get; set; }

    public virtual DbSet<CurrentAccounts> CurrentAccounts { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Movements> Movements { get; set; }

    public virtual DbSet<SavingAccounts> SavingAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;port=5433;Database=bootcampp2;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_pkey");

            entity.HasIndex(e => e.CurrencyId, "IX_Accounts_CurrencyId");

            entity.HasIndex(e => e.CustomerId, "IX_Accounts_CustomerId");

            entity.Property(e => e.Balance).HasPrecision(20, 5);
            entity.Property(e => e.Number).HasMaxLength(100);

            entity.HasOne(d => d.Currency).WithMany(p => p.Accounts).HasForeignKey(d => d.CurrencyId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Banks>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Bank_pkey");

            entity.Property(e => e.Address).HasMaxLength(400);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Phone).HasMaxLength(150);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Currency_pkey");

            entity.Property(e => e.BuyValue).HasPrecision(20, 5);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SellValue).HasPrecision(20, 5);
        });

        modelBuilder.Entity<CurrentAccounts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CurrentAccount_pkey");

            entity.HasIndex(e => e.AccountId, "IX_CurrentAccounts_AccountId");

            entity.Property(e => e.Interest).HasPrecision(10, 5);
            entity.Property(e => e.MonthAverage).HasPrecision(20, 5);
            entity.Property(e => e.OperationalLimit).HasPrecision(20, 5);

            entity.HasOne(d => d.Account).WithMany(p => p.CurrentAccounts).HasForeignKey(d => d.AccountId);
        });

        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pkey");

            entity.HasIndex(e => e.BankId, "IX_Customers_BankId");

            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.DocumentNumber).HasMaxLength(200);
            entity.Property(e => e.Lastname).HasMaxLength(200);
            entity.Property(e => e.Mail).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(200);

            entity.HasOne(d => d.Bank).WithMany(p => p.Customers).HasForeignKey(d => d.BankId);
        });

        modelBuilder.Entity<Movements>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Movements_pkey");

            entity.HasIndex(e => e.AccountId, "IX_Movements_AccountId");

            entity.Property(e => e.Destination).HasMaxLength(150);

            entity.HasOne(d => d.Account).WithMany(p => p.Movements).HasForeignKey(d => d.AccountId);
        });

        modelBuilder.Entity<SavingAccounts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SavingAccount_pkey");

            entity.HasIndex(e => e.AccountId, "IX_SavingAccounts_AccountId");

            entity.Property(e => e.HolderName).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany(p => p.SavingAccounts).HasForeignKey(d => d.AccountId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
