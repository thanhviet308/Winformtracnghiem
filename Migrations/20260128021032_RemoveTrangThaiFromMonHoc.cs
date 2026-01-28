using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhanMemThiTracNghiem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrangThaiFromMonHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trang_thai",
                table: "mon_hoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "trang_thai",
                table: "mon_hoc",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
