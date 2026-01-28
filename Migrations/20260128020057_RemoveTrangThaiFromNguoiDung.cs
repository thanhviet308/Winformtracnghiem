using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhanMemThiTracNghiem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrangThaiFromNguoiDung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trang_thai",
                table: "nguoi_dung");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
