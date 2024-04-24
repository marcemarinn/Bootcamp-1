using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity
           .HasKey(e => e.Id)
           .HasName("Products_pkey");

        entity
            .HasMany(p => p.ProductsRequest)
            .WithOne(pr => pr.Product)
            .HasForeignKey(pr => pr.Id);
    }
}

