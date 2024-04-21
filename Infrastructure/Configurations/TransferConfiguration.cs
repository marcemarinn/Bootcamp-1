using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> entity)
    {
        entity
           .HasKey(e => e.Id)
           .HasName("Transfer_pkey");
        
                entity
                    .HasOne(t => t.Currency)
                    .WithMany(c => c.Transfers)
                    .HasForeignKey(t => t.CurrencyId);

        entity
                .HasOne(t => t.SenderAccount)
                .WithMany(sa => sa.TransfersSent)
                .HasForeignKey(t => t.SenderId);


        entity
                .HasOne(t => t.ReceiverAccount)
                .WithMany(sa => sa.TransfersReceived)
                .HasForeignKey(t => t.ReceiverId);

    }
}
