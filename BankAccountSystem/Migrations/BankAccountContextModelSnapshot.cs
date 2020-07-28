﻿// <auto-generated />
using System;
using BankAccountSystem.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankAccountSystem.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    partial class BankAccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankAccountSystem.Model.BankAccount", b =>
                {
                    b.Property<Guid>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerRef")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankAccountId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("BankAccountSystem.Model.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("BankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Withdrawal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TransactionId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankAccountSystem.Model.Transaction", b =>
                {
                    b.HasOne("BankAccountSystem.Model.BankAccount", "BankAccount")
                        .WithMany("Transaction")
                        .HasForeignKey("BankAccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
