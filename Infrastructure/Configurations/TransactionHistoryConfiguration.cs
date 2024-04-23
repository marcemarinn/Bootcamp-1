using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
{
    public void Configure(EntityTypeBuilder<TransactionHistory> entity)
    {

        entity
           .HasKey(e => e.Id)
           .HasName("TransactionHistory_pkey");

        
     

  

    }

}