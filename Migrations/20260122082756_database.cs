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
                name: "lop_hoc",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_lop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lop_hoc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mon_hoc",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_mon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trang_thai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mon_hoc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vai_tro",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_vai_tro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vai_tro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nguoi_dung",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ho_ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mat_khau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma_vai_tro = table.Column<long>(type: "bigint", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trang_thai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoi_dung", x => x.id);
                    table.ForeignKey(
                        name: "FK_nguoi_dung_vai_tro_ma_vai_tro",
                        column: x => x.ma_vai_tro,
                        principalTable: "vai_tro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "cau_hoi_thi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_mon = table.Column<long>(type: "bigint", nullable: true),
                    noi_dung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nguoi_tao = table.Column<long>(type: "bigint", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trang_thai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cau_hoi_thi", x => x.id);
                    table.ForeignKey(
                        name: "FK_cau_hoi_thi_mon_hoc_ma_mon",
                        column: x => x.ma_mon,
                        principalTable: "mon_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_cau_hoi_thi_nguoi_dung_nguoi_tao",
                        column: x => x.nguoi_tao,
                        principalTable: "nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "lop_hoc_sinh_vien",
                columns: table => new
                {
                    ma_lop = table.Column<long>(type: "bigint", nullable: false),
                    ma_sinh_vien = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lop_hoc_sinh_vien", x => new { x.ma_lop, x.ma_sinh_vien });
                    table.ForeignKey(
                        name: "FK_lop_hoc_sinh_vien_lop_hoc_ma_lop",
                        column: x => x.ma_lop,
                        principalTable: "lop_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lop_hoc_sinh_vien_nguoi_dung_ma_sinh_vien",
                        column: x => x.ma_sinh_vien,
                        principalTable: "nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ngan_hang_de",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_mon = table.Column<long>(type: "bigint", nullable: true),
                    ten_de = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    tong_so_cau = table.Column<int>(type: "int", nullable: false),
                    nguoi_tao = table.Column<long>(type: "bigint", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ngan_hang_de", x => x.id);
                    table.ForeignKey(
                        name: "FK_ngan_hang_de_mon_hoc_ma_mon",
                        column: x => x.ma_mon,
                        principalTable: "mon_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ngan_hang_de_nguoi_dung_nguoi_tao",
                        column: x => x.nguoi_tao,
                        principalTable: "nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "phan_cong_giang_day",
                columns: table => new
                {
                    ma_lop = table.Column<long>(type: "bigint", nullable: false),
                    ma_mon = table.Column<long>(type: "bigint", nullable: false),
                    ma_giang_vien = table.Column<long>(type: "bigint", nullable: true),
                    ngay_phan_cong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phan_cong_giang_day", x => new { x.ma_lop, x.ma_mon });
                    table.ForeignKey(
                        name: "FK_phan_cong_giang_day_lop_hoc_ma_lop",
                        column: x => x.ma_lop,
                        principalTable: "lop_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phan_cong_giang_day_mon_hoc_ma_mon",
                        column: x => x.ma_mon,
                        principalTable: "mon_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phan_cong_giang_day_nguoi_dung_ma_giang_vien",
                        column: x => x.ma_giang_vien,
                        principalTable: "nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "lua_chon_trac_nghiem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_cau_hoi = table.Column<long>(type: "bigint", nullable: true),
                    noi_dung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    la_dap_an_dung = table.Column<bool>(type: "bit", nullable: false),
                    thu_tu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lua_chon_trac_nghiem", x => x.id);
                    table.ForeignKey(
                        name: "FK_lua_chon_trac_nghiem_cau_hoi_thi_ma_cau_hoi",
                        column: x => x.ma_cau_hoi,
                        principalTable: "cau_hoi_thi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cau_truc_de",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_ngan_hang_de = table.Column<long>(type: "bigint", nullable: true),
                    ma_mon = table.Column<long>(type: "bigint", nullable: true),
                    so_cau = table.Column<int>(type: "int", nullable: false),
                    so_cau_co_ban = table.Column<int>(type: "int", nullable: true),
                    so_cau_nang_cao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cau_truc_de", x => x.id);
                    table.ForeignKey(
                        name: "FK_cau_truc_de_mon_hoc_ma_mon",
                        column: x => x.ma_mon,
                        principalTable: "mon_hoc",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_cau_truc_de_ngan_hang_de_ma_ngan_hang_de",
                        column: x => x.ma_ngan_hang_de,
                        principalTable: "ngan_hang_de",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ky_thi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_ngan_hang_de = table.Column<long>(type: "bigint", nullable: true),
                    ten_ky_thi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ma_lop = table.Column<long>(type: "bigint", nullable: true),
                    thoi_gian_bat_dau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thoi_gian_ket_thuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thoi_luong_phut = table.Column<int>(type: "int", nullable: false),
                    tron_cau_hoi = table.Column<bool>(type: "bit", nullable: false),
                    tron_dap_an = table.Column<bool>(type: "bit", nullable: false),
                    tong_diem = table.Column<int>(type: "int", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ky_thi", x => x.id);
                    table.ForeignKey(
                        name: "FK_ky_thi_lop_hoc_ma_lop",
                        column: x => x.ma_lop,
                        principalTable: "lop_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ky_thi_ngan_hang_de_ma_ngan_hang_de",
                        column: x => x.ma_ngan_hang_de,
                        principalTable: "ngan_hang_de",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "bai_thi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_ky_thi = table.Column<long>(type: "bigint", nullable: true),
                    ma_sinh_vien = table.Column<long>(type: "bigint", nullable: true),
                    thoi_gian_bat_dau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    thoi_gian_nop_bai = table.Column<DateTime>(type: "datetime2", nullable: true),
                    diem_so = table.Column<int>(type: "int", nullable: true),
                    trang_thai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bai_thi", x => x.id);
                    table.ForeignKey(
                        name: "FK_bai_thi_ky_thi_ma_ky_thi",
                        column: x => x.ma_ky_thi,
                        principalTable: "ky_thi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bai_thi_nguoi_dung_ma_sinh_vien",
                        column: x => x.ma_sinh_vien,
                        principalTable: "nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "phan_cong_giam_sat",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_ky_thi = table.Column<long>(type: "bigint", nullable: true),
                    ma_giam_thi = table.Column<long>(type: "bigint", nullable: true),
                    ngay_phan_cong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phan_cong_giam_sat", x => x.id);
                    table.ForeignKey(
                        name: "FK_phan_cong_giam_sat_ky_thi_ma_ky_thi",
                        column: x => x.ma_ky_thi,
                        principalTable: "ky_thi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phan_cong_giam_sat_nguoi_dung_ma_giam_thi",
                        column: x => x.ma_giam_thi,
                        principalTable: "nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "nhat_ky_vi_pham",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_bai_thi = table.Column<long>(type: "bigint", nullable: true),
                    loai_vi_pham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_lan_vi_pham = table.Column<int>(type: "int", nullable: false),
                    lan_cuoi_xay_ra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhat_ky_vi_pham", x => x.id);
                    table.ForeignKey(
                        name: "FK_nhat_ky_vi_pham_bai_thi_ma_bai_thi",
                        column: x => x.ma_bai_thi,
                        principalTable: "bai_thi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tra_loi_bai_thi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_bai_thi = table.Column<long>(type: "bigint", nullable: true),
                    ma_cau_hoi = table.Column<long>(type: "bigint", nullable: true),
                    ma_lua_chon = table.Column<long>(type: "bigint", nullable: true),
                    dung_hay_sai = table.Column<bool>(type: "bit", nullable: true),
                    thoi_gian_tra_loi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tra_loi_bai_thi", x => x.id);
                    table.ForeignKey(
                        name: "FK_tra_loi_bai_thi_bai_thi_ma_bai_thi",
                        column: x => x.ma_bai_thi,
                        principalTable: "bai_thi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tra_loi_bai_thi_cau_hoi_thi_ma_cau_hoi",
                        column: x => x.ma_cau_hoi,
                        principalTable: "cau_hoi_thi",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tra_loi_bai_thi_lua_chon_trac_nghiem_ma_lua_chon",
                        column: x => x.ma_lua_chon,
                        principalTable: "lua_chon_trac_nghiem",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "vai_tro",
                columns: new[] { "id", "mo_ta", "ten_vai_tro" },
                values: new object[,]
                {
                    { 1L, "Quản trị viên hệ thống", "Admin" },
                    { 2L, "Giảng viên quản lý câu hỏi và đề thi", "Giảng viên" },
                    { 3L, "Sinh viên tham gia thi", "Sinh viên" }
                });

            migrationBuilder.InsertData(
                table: "nguoi_dung",
                columns: new[] { "id", "email", "ho_ten", "ma_vai_tro", "mat_khau", "ngay_tao", "trang_thai" },
                values: new object[] { 1L, "admin@gmail.com", "Quản trị viên", 1L, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.CreateIndex(
                name: "IX_bai_thi_ma_ky_thi",
                table: "bai_thi",
                column: "ma_ky_thi");

            migrationBuilder.CreateIndex(
                name: "IX_bai_thi_ma_sinh_vien",
                table: "bai_thi",
                column: "ma_sinh_vien");

            migrationBuilder.CreateIndex(
                name: "IX_cau_hoi_thi_ma_mon",
                table: "cau_hoi_thi",
                column: "ma_mon");

            migrationBuilder.CreateIndex(
                name: "IX_cau_hoi_thi_nguoi_tao",
                table: "cau_hoi_thi",
                column: "nguoi_tao");

            migrationBuilder.CreateIndex(
                name: "IX_cau_truc_de_ma_mon",
                table: "cau_truc_de",
                column: "ma_mon");

            migrationBuilder.CreateIndex(
                name: "IX_cau_truc_de_ma_ngan_hang_de",
                table: "cau_truc_de",
                column: "ma_ngan_hang_de");

            migrationBuilder.CreateIndex(
                name: "IX_ky_thi_ma_lop",
                table: "ky_thi",
                column: "ma_lop");

            migrationBuilder.CreateIndex(
                name: "IX_ky_thi_ma_ngan_hang_de",
                table: "ky_thi",
                column: "ma_ngan_hang_de");

            migrationBuilder.CreateIndex(
                name: "IX_lop_hoc_sinh_vien_ma_sinh_vien",
                table: "lop_hoc_sinh_vien",
                column: "ma_sinh_vien");

            migrationBuilder.CreateIndex(
                name: "IX_lua_chon_trac_nghiem_ma_cau_hoi",
                table: "lua_chon_trac_nghiem",
                column: "ma_cau_hoi");

            migrationBuilder.CreateIndex(
                name: "IX_ngan_hang_de_ma_mon",
                table: "ngan_hang_de",
                column: "ma_mon");

            migrationBuilder.CreateIndex(
                name: "IX_ngan_hang_de_nguoi_tao",
                table: "ngan_hang_de",
                column: "nguoi_tao");

            migrationBuilder.CreateIndex(
                name: "IX_nguoi_dung_email",
                table: "nguoi_dung",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nguoi_dung_ma_vai_tro",
                table: "nguoi_dung",
                column: "ma_vai_tro");

            migrationBuilder.CreateIndex(
                name: "IX_nhat_ky_vi_pham_ma_bai_thi",
                table: "nhat_ky_vi_pham",
                column: "ma_bai_thi");

            migrationBuilder.CreateIndex(
                name: "IX_phan_cong_giam_sat_ma_giam_thi",
                table: "phan_cong_giam_sat",
                column: "ma_giam_thi");

            migrationBuilder.CreateIndex(
                name: "IX_phan_cong_giam_sat_ma_ky_thi",
                table: "phan_cong_giam_sat",
                column: "ma_ky_thi");

            migrationBuilder.CreateIndex(
                name: "IX_phan_cong_giang_day_ma_giang_vien",
                table: "phan_cong_giang_day",
                column: "ma_giang_vien");

            migrationBuilder.CreateIndex(
                name: "IX_phan_cong_giang_day_ma_mon",
                table: "phan_cong_giang_day",
                column: "ma_mon");

            migrationBuilder.CreateIndex(
                name: "IX_tra_loi_bai_thi_ma_bai_thi",
                table: "tra_loi_bai_thi",
                column: "ma_bai_thi");

            migrationBuilder.CreateIndex(
                name: "IX_tra_loi_bai_thi_ma_cau_hoi",
                table: "tra_loi_bai_thi",
                column: "ma_cau_hoi");

            migrationBuilder.CreateIndex(
                name: "IX_tra_loi_bai_thi_ma_lua_chon",
                table: "tra_loi_bai_thi",
                column: "ma_lua_chon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cau_truc_de");

            migrationBuilder.DropTable(
                name: "lop_hoc_sinh_vien");

            migrationBuilder.DropTable(
                name: "nhat_ky_vi_pham");

            migrationBuilder.DropTable(
                name: "phan_cong_giam_sat");

            migrationBuilder.DropTable(
                name: "phan_cong_giang_day");

            migrationBuilder.DropTable(
                name: "tra_loi_bai_thi");

            migrationBuilder.DropTable(
                name: "bai_thi");

            migrationBuilder.DropTable(
                name: "lua_chon_trac_nghiem");

            migrationBuilder.DropTable(
                name: "ky_thi");

            migrationBuilder.DropTable(
                name: "cau_hoi_thi");

            migrationBuilder.DropTable(
                name: "lop_hoc");

            migrationBuilder.DropTable(
                name: "ngan_hang_de");

            migrationBuilder.DropTable(
                name: "mon_hoc");

            migrationBuilder.DropTable(
                name: "nguoi_dung");

            migrationBuilder.DropTable(
                name: "vai_tro");
        }
    }
}
