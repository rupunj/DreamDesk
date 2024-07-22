﻿// <auto-generated />
using DiscountGRPC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiscountGRPC.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("DiscountGRPC.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 10,
                            Description = "Discount on Product 1",
                            ProductName = "Smartphone X"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 20,
                            Description = "Discount on Product 2",
                            ProductName = "Tablet Y"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 30,
                            Description = "Discount on Product 3",
                            ProductName = "Product 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
