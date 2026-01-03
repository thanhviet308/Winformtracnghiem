using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhanMemThiTracNghiem.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MONTHI",
                columns: table => new
                {
                    MAMT = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    STT = table.Column<int>(type: "int", nullable: true),
                    TENMT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONTHI", x => x.MAMT);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    MAROLE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENROLE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.MAROLE);
                });

            migrationBuilder.CreateTable(
                name: "DETHI",
                columns: table => new
                {
                    MADETHI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: true),
                    MAKITHI = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    MAMT = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    MONTHIMAMT = table.Column<string>(type: "varchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETHI", x => x.MADETHI);
                    table.ForeignKey(
                        name: "FK_DETHI_MONTHI_MONTHIMAMT",
                        column: x => x.MONTHIMAMT,
                        principalTable: "MONTHI",
                        principalColumn: "MAMT");
                });

            migrationBuilder.CreateTable(
                name: "NGUOIDUNG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MATKHAU = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HOTEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MAROLE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGUOIDUNG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NGUOIDUNG_ROLE_MAROLE",
                        column: x => x.MAROLE,
                        principalTable: "ROLE",
                        principalColumn: "MAROLE");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETDETHI",
                columns: table => new
                {
                    MADETHI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MACAUHOI = table.Column<int>(type: "int", nullable: false),
                    MUCDO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DETHIMADETHI = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETDETHI", x => new { x.MADETHI, x.MACAUHOI });
                    table.ForeignKey(
                        name: "FK_CHITIETDETHI_DETHI_DETHIMADETHI",
                        column: x => x.DETHIMADETHI,
                        principalTable: "DETHI",
                        principalColumn: "MADETHI");
                });

            migrationBuilder.CreateTable(
                name: "CAUHOI",
                columns: table => new
                {
                    MACAUHOI = table.Column<int>(type: "int", nullable: false),
                    STT = table.Column<int>(type: "int", nullable: false),
                    NDCAUHOI = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DAPAN1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DAPAN2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DAPAN3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DAPAN4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DAPANDUNG = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MAGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MAMT = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    MONTHIMAMT = table.Column<string>(type: "varchar(40)", nullable: true),
                    NGUOIDUNGID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAUHOI", x => x.MACAUHOI);
                    table.ForeignKey(
                        name: "FK_CAUHOI_MONTHI_MONTHIMAMT",
                        column: x => x.MONTHIMAMT,
                        principalTable: "MONTHI",
                        principalColumn: "MAMT");
                    table.ForeignKey(
                        name: "FK_CAUHOI_NGUOIDUNG_NGUOIDUNGID",
                        column: x => x.NGUOIDUNGID,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETKYTHI",
                columns: table => new
                {
                    MAKITHI = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    MAMT = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    MASV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    DIEM = table.Column<double>(type: "float", nullable: true),
                    THOIGIANTHI = table.Column<int>(type: "int", nullable: true),
                    THOIGIANBD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    THOIGIANKT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NGUOIDUNGID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETKYTHI", x => new { x.MAKITHI, x.MAMT, x.MASV });
                    table.ForeignKey(
                        name: "FK_CHITIETKYTHI_MONTHI_MAMT",
                        column: x => x.MAMT,
                        principalTable: "MONTHI",
                        principalColumn: "MAMT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETKYTHI_NGUOIDUNG_NGUOIDUNGID",
                        column: x => x.NGUOIDUNGID,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KITHI",
                columns: table => new
                {
                    MAKITHI = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: true),
                    TENKITHI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ADMIN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    THOIGIANBDKITHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    THOIGIANKTKITHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NGUOIDUNGID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KITHI", x => x.MAKITHI);
                    table.ForeignKey(
                        name: "FK_KITHI_NGUOIDUNG_NGUOIDUNGID",
                        column: x => x.NGUOIDUNGID,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BANGDIEM",
                columns: table => new
                {
                    MASV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MAKITHI = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    MAMT = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: true),
                    DIEM = table.Column<double>(type: "float", nullable: true),
                    CHITIETKYTHIMAKITHI = table.Column<string>(type: "varchar(11)", nullable: true),
                    CHITIETKYTHIMAMT = table.Column<string>(type: "varchar(40)", nullable: true),
                    CHITIETKYTHIMASV = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANGDIEM", x => new { x.MASV, x.MAKITHI, x.MAMT });
                    table.ForeignKey(
                        name: "FK_BANGDIEM_CHITIETKYTHI_CHITIETKYTHIMAKITHI_CHITIETKYTHIMAMT_CHITIETKYTHIMASV",
                        columns: x => new { x.CHITIETKYTHIMAKITHI, x.CHITIETKYTHIMAMT, x.CHITIETKYTHIMASV },
                        principalTable: "CHITIETKYTHI",
                        principalColumns: new[] { "MAKITHI", "MAMT", "MASV" });
                });

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "MAROLE", "TENROLE" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Gi?ng viên" },
                    { 3, "Sinh viên" }
                });

            migrationBuilder.InsertData(
                table: "NGUOIDUNG",
                columns: new[] { "ID", "EMAIL", "HOTEN", "MAROLE", "MATKHAU" },
                values: new object[] { 1, "admin@gmail.com", "Qu?n tr? viên", 1, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92" });

            migrationBuilder.CreateIndex(
                name: "IX_BANGDIEM_CHITIETKYTHIMAKITHI_CHITIETKYTHIMAMT_CHITIETKYTHIMASV",
                table: "BANGDIEM",
                columns: new[] { "CHITIETKYTHIMAKITHI", "CHITIETKYTHIMAMT", "CHITIETKYTHIMASV" });

            migrationBuilder.CreateIndex(
                name: "IX_CAUHOI_MONTHIMAMT",
                table: "CAUHOI",
                column: "MONTHIMAMT");

            migrationBuilder.CreateIndex(
                name: "IX_CAUHOI_NGUOIDUNGID",
                table: "CAUHOI",
                column: "NGUOIDUNGID");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETDETHI_DETHIMADETHI",
                table: "CHITIETDETHI",
                column: "DETHIMADETHI");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETKYTHI_MAMT",
                table: "CHITIETKYTHI",
                column: "MAMT");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETKYTHI_NGUOIDUNGID",
                table: "CHITIETKYTHI",
                column: "NGUOIDUNGID");

            migrationBuilder.CreateIndex(
                name: "IX_DETHI_MONTHIMAMT",
                table: "DETHI",
                column: "MONTHIMAMT");

            migrationBuilder.CreateIndex(
                name: "IX_KITHI_NGUOIDUNGID",
                table: "KITHI",
                column: "NGUOIDUNGID");

            migrationBuilder.CreateIndex(
                name: "IX_NGUOIDUNG_EMAIL",
                table: "NGUOIDUNG",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NGUOIDUNG_MAROLE",
                table: "NGUOIDUNG",
                column: "MAROLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANGDIEM");

            migrationBuilder.DropTable(
                name: "CAUHOI");

            migrationBuilder.DropTable(
                name: "CHITIETDETHI");

            migrationBuilder.DropTable(
                name: "KITHI");

            migrationBuilder.DropTable(
                name: "CHITIETKYTHI");

            migrationBuilder.DropTable(
                name: "DETHI");

            migrationBuilder.DropTable(
                name: "NGUOIDUNG");

            migrationBuilder.DropTable(
                name: "MONTHI");

            migrationBuilder.DropTable(
                name: "ROLE");
        }
    }
}
