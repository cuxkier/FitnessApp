using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fitness.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kcal = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "Description", "DietName", "Kcal" },
                values: new object[,]
                {
                    { 1, "Dieta numer 1", "Dieta 1500kcal", 1500 },
                    { 2, "Dieta numer 2", "Dieta 200kcal", 1500 },
                    { 3, "Dieta numer 3", "Dieta 2500kcal", 1500 }
                });

            migrationBuilder.InsertData(
                table: "DietsCategory",
                columns: new[] { "Id", "CategoryName", "DisplayOrder" },
                values: new object[,]
                {
                    { 1, "Dieta Ketogeniczna", 1 },
                    { 2, "Dieta Wysokobiałkowa", 2 },
                    { 3, "Dieta Wegańska", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "DietsCategory");
        }
    }
}
