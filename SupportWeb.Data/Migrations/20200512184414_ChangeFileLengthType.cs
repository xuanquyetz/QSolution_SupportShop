using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportWeb.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanSu",
                keyColumn: "Ma",
                keyValue: new Guid("aed723a2-9ad3-4f2a-8753-da1b06ea5520"),
                columns: new[] { "BoPhan", "SoDienThoai" },
                values: new object[] { 3, 963555396 });

            migrationBuilder.UpdateData(
                table: "NhanSu",
                keyColumn: "Ma",
                keyValue: new Guid("fba9d758-5204-4e31-a2ea-d1466e947f23"),
                column: "BoPhan",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanSu",
                keyColumn: "Ma",
                keyValue: new Guid("aed723a2-9ad3-4f2a-8753-da1b06ea5520"),
                columns: new[] { "BoPhan", "SoDienThoai" },
                values: new object[] { 3, 963555396 });

            migrationBuilder.UpdateData(
                table: "NhanSu",
                keyColumn: "Ma",
                keyValue: new Guid("fba9d758-5204-4e31-a2ea-d1466e947f23"),
                column: "BoPhan",
                value: 3);
        }
    }
}
