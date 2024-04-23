using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Movements_pkey");

        
        entity
            .HasOne(x => x.Account)
            .WithMany(x => x.Movements)
            .HasForeignKey(x => x.AccountId);

        entity
            .HasMany(m => m.TransactionHistories)
            .WithOne(th => th.Movement)
            .HasForeignKey(th => th.MovementId);

    }
}
