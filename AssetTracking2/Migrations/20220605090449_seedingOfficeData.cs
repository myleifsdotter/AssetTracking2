using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking2.Migrations
{
    public partial class seedingOfficeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Country", "Currency" },
                values: new object[] { 1, "Sweden", "SEK" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Country", "Currency" },
                values: new object[] { 2, "Spain", "EUR" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Country", "Currency" },
                values: new object[] { 3, "USA", "USD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
