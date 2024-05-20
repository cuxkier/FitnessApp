using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fitness.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDietKategoryToDietsDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryDietId",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryDietId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryDietId", "DietName" },
                values: new object[] { 2, "Dieta 2000kcal" });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryDietId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "CategoryDietId", "Description", "DietName", "Kcal" },
                values: new object[,]
                {
                    { 4, 3, "Dieta numer 3", "Dieta 3000kcal", 1500 },
                    { 5, 2, "Dieta numer 3", "Dieta 3500kcal", 1500 },
                    { 6, 3, "Dieta numer 3", "Dieta 4000kcal", 1500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CategoryDietId",
                table: "Diets",
                column: "CategoryDietId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_DietsCategory_CategoryDietId",
                table: "Diets",
                column: "CategoryDietId",
                principalTable: "DietsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_DietsCategory_CategoryDietId",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_CategoryDietId",
                table: "Diets");

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CategoryDietId",
                table: "Diets");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 2,
                column: "DietName",
                value: "Dieta 200kcal");
        }
    }
}
