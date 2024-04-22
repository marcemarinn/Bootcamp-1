using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder
             .HasKey(x => x.Id)
             .HasName("Service_pkey");

        builder
            .HasMany(s => s.PaymentServices)
            .WithOne(sp => sp.Service)
            .HasForeignKey(x => x.ServiceId);
    }
}
