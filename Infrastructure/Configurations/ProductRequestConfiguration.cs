using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Configurations;

public class ProductRequestConfiguration : IEntityTypeConfiguration<ProductRequest>
{
    public void Configure(EntityTypeBuilder<ProductRequest> entity)
    {

        entity
        .HasKey(e => e.Id)
        .HasName("ProductsRequest_pkey");


        entity.HasOne(pr => pr.Product)
              .WithMany(p => p.ProductsRequest)
              .HasForeignKey(pr => pr.ProductId);


        entity.HasOne(pr => pr.Customer)
              .WithMany(c => c.ProductsRequest)
              .HasForeignKey(pr => pr.CustomerId);

        entity.HasOne(pr => pr.Currency)
              .WithMany(c => c.ProductRequests)
              .HasForeignKey(pr => pr.CurrencyId);




    }
}
