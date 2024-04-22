using Core.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ServicePaymentConfiguration : IEntityTypeConfiguration<ServicePayment>
{
    public void Configure(EntityTypeBuilder<ServicePayment> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("ServicePayment_pkey");

        entity
            .HasOne(sp => sp.Account)
            .WithMany(a => a.ServicePayments)
            .HasForeignKey(a => a.AccountId);

        entity
            .HasOne(sp => sp.Service)
            .WithMany(s => s.ServicePayments)
            .HasForeignKey(s => s.ServiceId);

    }
}
