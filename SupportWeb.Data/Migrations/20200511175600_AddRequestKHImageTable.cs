using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportWeb.Data.Migrations
{
    public partial class AddRequestKHImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequetKHImage",
                columns: table => new
                {
                    Ma = table.Column<string>(nullable: false),
                    RequestKHMa = table.Column<Guid>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    SoTTImage = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequetKHImage", x => x.Ma);
                    table.ForeignKey(
                        name: "FK_RequetKHImage_RequestKH_RequestKHMa",
                        column: x => x.RequestKHMa,
                        principalTable: "RequestKH",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RequetKHImage_RequestKHMa",
                table: "RequetKHImage",
                column: "RequestKHMa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequetKHImage");

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
