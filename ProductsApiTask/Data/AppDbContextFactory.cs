using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductsApiTask.Data
{
    // Kjo klase eshte e nevojshme per te mundesuar migrimet dhe per te krijuar DbContext ne kohen e dizajnit (design time).
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            //Krijojme DbContextOptionsBuilder dhe i konfigurrojme me connection string per te lidhur me databazen SQL Server.
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-9DMH3TEE\\SQLEXPRESS;Database=ProductsDb;Trusted_Connection=True;TrustServerCertificate=True;");
            //Siguron funksionim te migrations edhe nese program.cs nuk ekzekutohet ne kohen e dizajnit.
            
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}