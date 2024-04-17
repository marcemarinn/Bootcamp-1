using Core.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

