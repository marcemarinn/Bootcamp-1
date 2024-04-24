﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BootcampContext))]
    [Migration("20240424005007_fix15")]
    partial class fix15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Balance")
                        .HasPrecision(20, 5)
                        .HasColumnType("numeric(20,5)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Holder")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Account_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Core.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<int?>("BankId")
                        .HasColumnType("integer");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id")
                        .HasName("Bank_pkey");

                    b.HasIndex("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Core.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BuyValue")
                        .HasColumnType("numeric(20,5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("SellValue")
                        .HasColumnType("numeric(20,5)");

                    b.HasKey("Id")
                        .HasName("Currency_pkey");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Core.Entities.CurrentAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Interest")
                        .HasColumnType("numeric(10,5)");

                    b.Property<decimal?>("MonthAverage")
                        .HasColumnType("numeric(20,5)");

                    b.Property<decimal?>("OperationalLimit")
                        .HasColumnType("numeric(20,5)");

                    b.HasKey("Id")
                        .HasName("CurrentAccount_pkey");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("CurrentAccounts");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<int>("BankId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerStatus")
                        .HasColumnType("integer");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Mail")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Phone")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Customer_pkey");

                    b.HasIndex("BankId");

                    b.HasIndex("ProductId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("BankId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("Deposit_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("BankId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Core.Entities.Enterprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Enterprises");
                });

            modelBuilder.Entity("Core.Entities.Extraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("BankId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OperationalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Extraction_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("BankId");

                    b.ToTable("Extractions");
                });

            modelBuilder.Entity("Core.Entities.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OperationalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Movements_pkey");

                    b.HasIndex("AccountId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("Products_pkey");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Core.Entities.ProductRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("AplicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("LoanTerm")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("ProductsRequest_pkey");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRequests");
                });

            modelBuilder.Entity("Core.Entities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Core.Entities.PromotionEnterprise", b =>
                {
                    b.Property<int>("PromotionId")
                        .HasColumnType("integer");

                    b.Property<int>("EnterpriseId")
                        .HasColumnType("integer");

                    b.HasKey("PromotionId", "EnterpriseId");

                    b.HasIndex("EnterpriseId");

                    b.ToTable("PromotionEnterprises");
                });

            modelBuilder.Entity("Core.Entities.SavingAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("SavingType")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("SavingAccount_pkey");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("SavingAccounts");
                });

            modelBuilder.Entity("Core.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("Service_pkey");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Core.Entities.ServicePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("ServicePayment_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServicePayments");
                });

            modelBuilder.Entity("Core.Entities.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MovementId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("TransactionHistory_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("MovementId");

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("Core.Entities.TransactionLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DestinationAccountId")
                        .HasColumnType("integer");

                    b.Property<int>("OriginAccountId")
                        .HasColumnType("integer");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TransactionalLimit")
                        .HasColumnType("numeric");

                    b.HasKey("Id")
                        .HasName("TransactionLimit_pkey");

                    b.HasIndex("DestinationAccountId");

                    b.HasIndex("OriginAccountId");

                    b.ToTable("TransactionLimits");
                });

            modelBuilder.Entity("Core.Entities.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransferDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("Transfer_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Core.Entities.Account", b =>
                {
                    b.HasOne("Core.Entities.Account", null)
                        .WithMany("Accounts")
                        .HasForeignKey("AccountId");

                    b.HasOne("Core.Entities.Currency", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Core.Entities.Bank", b =>
                {
                    b.HasOne("Core.Entities.Bank", null)
                        .WithMany("Banks")
                        .HasForeignKey("BankId");
                });

            modelBuilder.Entity("Core.Entities.CurrentAccount", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithOne("CurrentAccount")
                        .HasForeignKey("Core.Entities.CurrentAccount", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.HasOne("Core.Entities.Bank", "Bank")
                        .WithMany("Customers")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Product", null)
                        .WithMany("Customers")
                        .HasForeignKey("ProductId");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Core.Entities.Deposit", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithMany("Deposits")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Bank", "Bank")
                        .WithMany("Deposits")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Core.Entities.Extraction", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithMany("Extractions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Bank", null)
                        .WithMany("Extractions")
                        .HasForeignKey("BankId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Core.Entities.Movement", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithMany("Movements")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Core.Entities.ProductRequest", b =>
                {
                    b.HasOne("Core.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany("ProductsRequest")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Product", "Product")
                        .WithMany("ProductsRequest")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Entities.PromotionEnterprise", b =>
                {
                    b.HasOne("Core.Entities.Enterprise", "Enterprise")
                        .WithMany("PromotionsEnterprises")
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Promotion", "Promotion")
                        .WithMany("PromotionsEnterprises")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enterprise");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Core.Entities.SavingAccount", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithOne("SavingAccount")
                        .HasForeignKey("Core.Entities.SavingAccount", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Core.Entities.ServicePayment", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithMany("PaymentServices")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Service", "Service")
                        .WithMany("PaymentServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Core.Entities.TransactionHistory", b =>
                {
                    b.HasOne("Core.Entities.Account", "Account")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Movement", "Movement")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("MovementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Movement");
                });

            modelBuilder.Entity("Core.Entities.TransactionLimit", b =>
                {
                    b.HasOne("Core.Entities.Account", "AccountDestiny")
                        .WithMany("TransactionLimitsDestiny")
                        .HasForeignKey("DestinationAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Account", "AccountOrigin")
                        .WithMany("TransactionLimitsOrigin")
                        .HasForeignKey("OriginAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDestiny");

                    b.Navigation("AccountOrigin");
                });

            modelBuilder.Entity("Core.Entities.Transfer", b =>
                {
                    b.HasOne("Core.Entities.Account", null)
                        .WithMany("Transfers")
                        .HasForeignKey("AccountId");

                    b.HasOne("Core.Entities.Currency", "Currency")
                        .WithMany("Transfers")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Account", "ReceiverAccount")
                        .WithMany("TransfersReceived")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Account", "SenderAccount")
                        .WithMany("TransfersSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("ReceiverAccount");

                    b.Navigation("SenderAccount");
                });

            modelBuilder.Entity("Core.Entities.Account", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("CurrentAccount");

                    b.Navigation("Deposits");

                    b.Navigation("Extractions");

                    b.Navigation("Movements");

                    b.Navigation("PaymentServices");

                    b.Navigation("SavingAccount");

                    b.Navigation("TransactionHistories");

                    b.Navigation("TransactionLimitsDestiny");

                    b.Navigation("TransactionLimitsOrigin");

                    b.Navigation("Transfers");

                    b.Navigation("TransfersReceived");

                    b.Navigation("TransfersSent");
                });

            modelBuilder.Entity("Core.Entities.Bank", b =>
                {
                    b.Navigation("Banks");

                    b.Navigation("Customers");

                    b.Navigation("Deposits");

                    b.Navigation("Extractions");
                });

            modelBuilder.Entity("Core.Entities.Currency", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("ProductsRequest");
                });

            modelBuilder.Entity("Core.Entities.Enterprise", b =>
                {
                    b.Navigation("PromotionsEnterprises");
                });

            modelBuilder.Entity("Core.Entities.Movement", b =>
                {
                    b.Navigation("TransactionHistories");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("ProductsRequest");
                });

            modelBuilder.Entity("Core.Entities.Promotion", b =>
                {
                    b.Navigation("PromotionsEnterprises");
                });

            modelBuilder.Entity("Core.Entities.Service", b =>
                {
                    b.Navigation("PaymentServices");
                });
#pragma warning restore 612, 618
        }
    }
}
