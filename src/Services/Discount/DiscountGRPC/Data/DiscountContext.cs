using DiscountGRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountGRPC.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }
    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Smartphone X", Description = "Discount on Product 1", Amount = 10 },
            new Coupon { Id = 2, ProductName = "Tablet Y", Description = "Discount on Product 2", Amount = 20 },
            new Coupon { Id = 3, ProductName = "Product 3", Description = "Discount on Product 3", Amount = 30 }

        );
    }
}
