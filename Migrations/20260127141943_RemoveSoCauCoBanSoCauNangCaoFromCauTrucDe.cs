using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhanMemThiTracNghiem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSoCauCoBanSoCauNangCaoFromCauTrucDe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "so_cau_co_ban",
                table: "cau_truc_de");

            migrationBuilder.DropColumn(
                name: "so_cau_nang_cao",
                table: "cau_truc_de");

            migrationBuilder.AddColumn<bool>(
                name: "trang_thai",
                table: "nguoi_dung",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "nguoi_dung",
                keyColumn: "id",
                keyValue: 1L,
                column: "trang_thai",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trang_thai",
                table: "nguoi_dung");

            migrationBuilder.AddColumn<int>(
                name: "so_cau_co_ban",
                table: "cau_truc_de",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "so_cau_nang_cao",
                table: "cau_truc_de",
                type: "int",
                nullable: true);
        }
    }
}
