using Core.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
       builder
            .HasKey(x => x.Id)
            .HasName("Service_pkey");

        builder
            .HasMany(s => s.ServicePayments)
            .WithOne(sp => sp.Service)
            .HasForeignKey(x => x.ServiceId);
    }
}
