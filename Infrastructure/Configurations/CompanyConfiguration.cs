using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.HasKey(e => e.Id);

        entity
            .Property(e => e.Name)
            .IsRequired();

        entity
            .Property(e => e.Address)
            .IsRequired();

        entity
            .Property(e => e.PhoneNumber)
            .IsRequired();

        entity
            .Property(e => e.Email)
            .IsRequired();

        entity
            .HasMany(e => e.CompanyPromotion)
            .WithOne(pe => pe.Company)
            .HasForeignKey(pe => pe.CompanyId);


    }
}
