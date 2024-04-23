using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExtractionConfiguration : IEntityTypeConfiguration<Extraction>
{
    public void Configure(EntityTypeBuilder<Extraction> builder)
    {
        builder
            .HasKey(x => x.Id)
            .HasName("Extraction_pkey");

        builder
            .HasOne(e => e.Account)
            .WithMany(a => a.Extractions)
            .HasForeignKey(e => e.AccountId);


        
    }

}

