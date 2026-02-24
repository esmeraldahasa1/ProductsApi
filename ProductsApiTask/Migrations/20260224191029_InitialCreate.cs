using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApiTask.Migrations
{
    /// <summary>
    ///     InititalCreate eshte emri i migrimit te pare qe krijohet per te inicializuar databazen me tabelen "Products" bazuar ne modelin e Product dhe konfigurimet e AppDbContext.
    /// </summary>
    public partial class InitialCreate : Migration
    {
       /// <summary>
       /// Krijohet struktura e tabeles.
       /// </summary>
       /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cmimi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sasia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        /// <summary>
        /// Nese bejme downgrade metoda Down perdoret per rollback, fshin tabelen.
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
