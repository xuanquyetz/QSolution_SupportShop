using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportWeb.Data.Migrations
{
    public partial class Initiai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhacHang",
                columns: table => new
                {
                    Ma = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<int>(maxLength: 11, nullable: false, defaultValue: 0),
                    DiaChi = table.Column<string>(maxLength: 500, nullable: true),
                    NguoiChiuTrachNhiem = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    ThongTinSupport = table.Column<string>(maxLength: 200, nullable: true),
                    NhanSuPhuTrachMa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhacHang", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "NhanSu",
                columns: table => new
                {
                    Ma = table.Column<Guid>(nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: true),
                    ChucVu = table.Column<string>(nullable: true),
                    BoPhan = table.Column<int>(nullable: false, defaultValue: 3),
                    SoDienThoai = table.Column<int>(maxLength: 11, nullable: false, defaultValue: 0),
                    NgaySinh = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSu", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "RequestKH",
                columns: table => new
                {
                    Ma = table.Column<Guid>(nullable: false),
                    Stt = table.Column<int>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    CodeMa = table.Column<Guid>(nullable: false),
                    KyThuatMa = table.Column<Guid>(nullable: false),
                    KhachHangMa = table.Column<Guid>(nullable: false),
                    FormThucHien = table.Column<string>(maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(maxLength: 500, nullable: true),
                    NguoiYeuCau = table.Column<string>(maxLength: 100, nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestKH", x => x.Ma);
                    table.ForeignKey(
                        name: "FK_RequestKH_NhanSu_CodeMa",
                        column: x => x.CodeMa,
                        principalTable: "NhanSu",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestKH_KhacHang_KhachHangMa",
                        column: x => x.KhachHangMa,
                        principalTable: "KhacHang",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestKH_CodeMa",
                table: "RequestKH",
                column: "CodeMa");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKH_KhachHangMa",
                table: "RequestKH",
                column: "KhachHangMa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestKH");

            migrationBuilder.DropTable(
                name: "NhanSu");

            migrationBuilder.DropTable(
                name: "KhacHang");
        }
    }
}
