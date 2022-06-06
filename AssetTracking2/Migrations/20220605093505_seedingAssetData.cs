using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking2.Migrations
{
    public partial class seedingAssetData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Brand", "Model", "OfficeId", "PriceUSD", "Purchasedate", "Type" },
                values: new object[,]
                {
                    { 1, "iPhone", "8", 2, 970.0, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 2, "HP", "Elitebook", 2, 1423.0, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 3, "iPhone", "11", 2, 990.0, new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 4, "iPhone", "X", 1, 1245.0, new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 5, "Motorola", "Razr", 1, 970.0, new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 6, "HP", "Elitebook", 1, 588.0, new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 7, "Asus", "W234", 3, 1200.0, new DateTime(2019, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 8, "Lenovo", "Yoga 730", 3, 835.0, new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 9, "Lenovo", "Yoga 530", 3, 1030.0, new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 10, "Samsung", "Galaxy", 3, 1170.0, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
