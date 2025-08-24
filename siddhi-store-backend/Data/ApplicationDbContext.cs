using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using siddhi_store_backend.Models;

namespace siddhi_store_backend.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        
       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // One-to-many relationship for Products & SubProducts
    modelBuilder.Entity<Product>()
        .HasMany(p => p.SubProducts)
        .WithOne(sp => sp.Product)
        .HasForeignKey(sp => sp.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

    // One-to-many relationship for SubProducts & ProductItems
    modelBuilder.Entity<SubProduct>()
        .HasMany(sp => sp.ProductItems)
        .WithOne(pi => pi.SubProduct)
        .HasForeignKey(pi => pi.SubProductId)
        .OnDelete(DeleteBehavior.Restrict);  // Changed from Cascade to Restrict

    // Configure Product to ProductItem direct relation
    modelBuilder.Entity<Product>()
        .HasMany(p => p.ProductItems)
        .WithOne(pi => pi.Product)
        .HasForeignKey(pi => pi.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

    // Configure ProductType to ProductItem relation
    modelBuilder.Entity<ProductType>()
        .HasMany(pt => pt.ProductItems)
        .WithOne(pi => pi.ProductType)
        .HasForeignKey(pi => pi.ProductTypeId)
        .OnDelete(DeleteBehavior.SetNull);
}

    }
}
