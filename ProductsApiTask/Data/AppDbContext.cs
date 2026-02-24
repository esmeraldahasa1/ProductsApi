using Microsoft.EntityFrameworkCore;
using ProductsApiTask.Models;

namespace ProductsApiTask.Data
{
    //AppDbContext perfaqeson sesionin me databazen.
    //Trashegon nga DbContext dhe permban DbSet<Product> per te menaxhuar produktet ne databaze.
    public class AppDbContext : DbContext
    {
        //Lejon konfigurimin e connection string nga Program.cs
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        // EF Core do te krijoje nje tabele "Products" ne databaze bazuar ne kete DbSet
        public DbSet<Product> Products { get; set; }

        //Fluent API per te konfiguruar modelin e Product, specifikisht per te vendosur precizionin e fushes Cmimi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Cmimi)
                .HasPrecision(18, 2);  // 18 total digits, 2 after decimal

            base.OnModelCreating(modelBuilder);
        }
    }
}