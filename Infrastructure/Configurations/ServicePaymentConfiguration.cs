using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
            .WithMany(a => a.PaymentServices)
            .HasForeignKey(a => a.AccountId);

        entity
            .HasOne(sp => sp.Service)
            .WithMany(s => s.PaymentServices)
            .HasForeignKey(s => s.ServiceId);

    }
}
