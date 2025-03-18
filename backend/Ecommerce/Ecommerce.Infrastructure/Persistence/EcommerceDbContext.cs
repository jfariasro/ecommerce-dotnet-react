using Ecommerce.Domain.Modules.Auth.Models;
using Ecommerce.Domain.Modules.Order.Models;
using Ecommerce.Domain.Modules.ProductCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContext : IdentityDbContext<User>
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Product>()
            .HasMany(p => p.Reviews)
            .WithOne(r => r.Product)
            .HasForeignKey(r => r.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasMany(p => p.ProductImages)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ShoppingCart>()
            .HasMany(s => s.ShoppingCartItems)
            .WithOne(i => i.ShoppingCart)
            .HasForeignKey(i => i.ShoppingCartId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<User>().Property(u => u.Id).HasMaxLength(36);
        builder.Entity<User>().Property(u => u.NormalizedUserName).HasMaxLength(90);
        builder.Entity<IdentityRole>().Property(r => r.Id).HasMaxLength(36);
        builder.Entity<IdentityRole>().Property(r => r.NormalizedName).HasMaxLength(90);
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Address> Address { get; set; }

    public DbSet<Country> Country { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderAddress> OrderAddress { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<ShoppingCart> shoppingCarts { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}
