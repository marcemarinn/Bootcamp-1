using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class CompanyPromotionConfiguration : IEntityTypeConfiguration<CompanyPromotion>
    {
        public void Configure(EntityTypeBuilder<CompanyPromotion> builder)
        {

            builder.HasKey(pc => new { pc.PromotionId, pc.CompanyId });

            builder.HasOne(pc => pc.Promotion)
                .WithMany(p => p.CompanyPromotion)
                .HasForeignKey(pc => pc.PromotionId);

            builder.HasOne(pc => pc.Company)
                .WithMany(c => c.CompanyPromotion)
                .HasForeignKey(pc => pc.CompanyId);


        }



    }
}
