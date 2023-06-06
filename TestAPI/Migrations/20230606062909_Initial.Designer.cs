﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAPI.Data;

#nullable disable

namespace TestAPI.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20230606062909_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestAPI.Models.CountryModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CouponModelID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CouponModelID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TestAPI.Models.CouponCountryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CouponCountries");
                });

            modelBuilder.Entity("TestAPI.Models.CouponModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDateUTC")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("TestAPI.Models.CouponProductModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("CouponProducts");
                });

            modelBuilder.Entity("TestAPI.Models.ProductModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CouponModelID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CouponModelID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TestAPI.Models.CountryModel", b =>
                {
                    b.HasOne("TestAPI.Models.CouponModel", null)
                        .WithMany("ValidCountries")
                        .HasForeignKey("CouponModelID");
                });

            modelBuilder.Entity("TestAPI.Models.ProductModel", b =>
                {
                    b.HasOne("TestAPI.Models.CouponModel", null)
                        .WithMany("ValidProducts")
                        .HasForeignKey("CouponModelID");
                });

            modelBuilder.Entity("TestAPI.Models.CouponModel", b =>
                {
                    b.Navigation("ValidCountries");

                    b.Navigation("ValidProducts");
                });
#pragma warning restore 612, 618
        }
    }
}