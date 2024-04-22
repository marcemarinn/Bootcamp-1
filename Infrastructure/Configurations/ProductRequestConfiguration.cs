using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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




    }
}
