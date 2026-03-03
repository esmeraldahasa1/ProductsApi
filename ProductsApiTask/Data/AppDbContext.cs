using Microsoft.EntityFrameworkCore;
using ProductsApiTask.Models;

namespace ProductsApiTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Precision per Cmimi
            modelBuilder.Entity<Product>()
                .Property(p => p.Cmimi)
                .HasPrecision(18, 2);

            // Relationship 1 Category -> Many Products
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);
            // nuk lejon fshirjen e kategorise nese ka produkte

            base.OnModelCreating(modelBuilder);
        }
    }
}