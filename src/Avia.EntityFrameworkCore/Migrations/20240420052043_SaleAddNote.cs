﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avia.Migrations
{
    /// <inheritdoc />
    public partial class SaleAddNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "AppSales",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "AppSales");
        }
    }
}
