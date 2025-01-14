﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        entity.HasKey(e => e.Id).HasName("Account_pkey");
        entity.Property(e => e.Number).HasMaxLength(100);
        entity.Property(e => e.Balance).HasPrecision(20, 5);


        entity
            .HasOne(account => account.Currency)
            .WithMany(currency => currency.Accounts)
            .HasForeignKey(account => account.CurrencyId);

        entity
            .HasOne(account => account.Customer)
            .WithMany(customer => customer.Accounts)
            .HasForeignKey(account => account.CustomerId);

        entity
            .HasMany(account => account.Movements)
            .WithOne(movement => movement.Account)
            .HasForeignKey(movement => movement.AccountId);

        entity
            .HasMany(account => account.Movements)
            .WithOne(currentAccount => currentAccount.Account)
            .HasForeignKey(account => account.AccountId);

        entity
            .HasMany(account => account.SavingAccounts)
            .WithOne(savingAccount => savingAccount.Account)
            .HasForeignKey(account => account.AccountId);
    }
}
