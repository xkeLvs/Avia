using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "AppProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Temperature",
                table: "AppProducts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "AppProducts");
        }
    }
}
