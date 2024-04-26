using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public class ExternalAccountConfiguration : IEntityTypeConfiguration<ExternalAccount>
{
    public void Configure(EntityTypeBuilder<ExternalAccount> entity)
    {
        entity
           .HasKey(e => e.Id)
           .HasName("ExternalAccount_pkey");

        entity
            .HasOne(t => t.Currency)
            .WithMany(c => c.ExternalAccounts)
            .HasForeignKey(t => t.CurrencyId);

        entity
          .HasOne(t => t.Bank)
          .WithMany(b => b. ExternalAccounts)
          .HasForeignKey(t => t.BankId);




    }

}
