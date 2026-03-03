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
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Product>().Property(p => p.Cmimi) .HasPrecision(18, 2);

            // Konfigurimi i mardheniesise ndermjet Product dhe Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade); //Fshihet produkti ne momentin qe fshihet kategoria
        }
    }
}