using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportWeb.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NhanSu",
                columns: new[] { "Ma", "BoPhan", "ChucVu", "HoTen", "NgaySinh", "SoDienThoai" },
                values: new object[] { new Guid("aed723a2-9ad3-4f2a-8753-da1b06ea5520"), 3, "Leader", "Đinh Xuân Quyết", null, 963555396 });

            migrationBuilder.InsertData(
                table: "NhanSu",
                columns: new[] { "Ma", "BoPhan", "ChucVu", "HoTen", "NgaySinh" },
                values: new object[] { new Guid("fba9d758-5204-4e31-a2ea-d1466e947f23"), 3, "Leader", "Trần Gia Bảo", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NhanSu",
                keyColumn: "Ma",
                keyValue: new Guid("aed723a2-9ad3-4f2a-8753-da1b06ea5520"));

            migrationBuilder.DeleteData(
                table: "NhanSu",
                keyColumn: "Ma",
                keyValue: new Guid("fba9d758-5204-4e31-a2ea-d1466e947f23"));
        }
    }
}
