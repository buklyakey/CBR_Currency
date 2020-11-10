﻿// <auto-generated />
using CBR_Currency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CBR_Currency.Migrations
{
    [DbContext(typeof(DbCurrencyContext))]
    partial class DbCurrencyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CBR_Currency.Models.Currency", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CharCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nominal")
                        .HasColumnType("int");

                    b.Property<int>("NumCode")
                        .HasColumnType("int");

                    b.Property<double>("Previous")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Currencies");
                });
#pragma warning restore 612, 618
        }
    }
}
