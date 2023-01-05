using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Data.Migrations
{
    public partial class SeedingDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "018a701d-0e62-4cc5-a078-8c8187a9ed41", "3be2f1e4-b929-4a33-b1e8-051c50f9b26a", "ApplicationRole", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "82c0250e-375f-4807-8e71-b4ea10481dd8", "fb03baf3-5d40-4e90-aae1-6c6b42c137da", "ApplicationRole", "Vendor", "Vendor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "240153f8-4b96-4fa5-8bb6-1f1509da684f", "875d66c7-c0a0-435e-9585-b849d06b7af5", "ApplicationRole", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "018a701d-0e62-4cc5-a078-8c8187a9ed41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "240153f8-4b96-4fa5-8bb6-1f1509da684f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82c0250e-375f-4807-8e71-b4ea10481dd8");
        }
    }
}
