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
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {

        public void Configure(EntityTypeBuilder<CreditCard> entity)
        {
            entity.HasKey(e => e.Id).HasName("CreditCard_pkey");


            entity.HasOne(cc => cc.Customer)
                 .WithMany(customer => customer.CreditCards)
                 .HasForeignKey(cc => cc.CustomerId);
                 

            entity.HasOne(cc => cc.Currency) 
                .WithMany(currency => currency.CreditCards) 
                .HasForeignKey(cc => cc.CurrencyId); 
        }
    }
}
