using Core.Entities;
using Infrastructure.Configurations;
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

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrentAccount> CurrentAccounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<SavingAccount> SavingAccounts { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<CompanyPromotion> CompaniesPromotion { get; set; }

    public virtual DbSet<ProductRequest> ProductRequests { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<ServicePayment> ServicePayments { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new BankConfiguration());
        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        modelBuilder.ApplyConfiguration(new CurrentAccountConfiguration());
        modelBuilder.ApplyConfiguration(new SavingAccountConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new MovementConfiguration());
        modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyPromotionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductRequestConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());
        modelBuilder.ApplyConfiguration(new ServicePaymentConfiguration());






        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
