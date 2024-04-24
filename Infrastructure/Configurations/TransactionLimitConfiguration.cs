using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public class TransactionLimitConfiguration : IEntityTypeConfiguration<TransactionLimit>
{
    public void Configure(EntityTypeBuilder<TransactionLimit> entity)
    {

        entity
           .HasKey(e => e.Id)
           .HasName("TransactionLimit_pkey");


        entity.HasKey(e => e.Id)
            .HasName("TransactionLimit_pkey");

       

        entity
            .HasOne(tl => tl.AccountOrigin)
            .WithMany(a => a.TransactionLimitsOrigin)
            .HasForeignKey(tl => tl.OriginAccountId);

        entity.HasOne(tl => tl.AccountDestiny)
            .WithMany(a => a.TransactionLimitsDestiny)
            .HasForeignKey(tl => tl.DestinationAccountId);



    }

}