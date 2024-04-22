using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Deposit_pkey");

        entity
            .HasOne(d => d.Account)
            .WithMany(a => a.Deposits)
            .HasForeignKey(d => d.AccountId);

        entity
            .HasOne(d => d.Bank)
            .WithMany(b => b.Deposits)
            .HasForeignKey(d => d.BankId);
    }
}
