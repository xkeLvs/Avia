using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "AppProducts",
                newName: "DrinkSize");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrinkSize",
                table: "AppProducts",
                newName: "Size");
        }
    }
}
