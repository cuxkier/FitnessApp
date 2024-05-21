using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changePriceFromIntToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Diet",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Diet",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diet",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 0);
        }
    }
}
