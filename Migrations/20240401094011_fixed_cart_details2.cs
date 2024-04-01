using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine_Store.Migrations
{
    /// <inheritdoc />
    public partial class fixed_cart_details2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                schema: "medicine_store",
                table: "cart_details",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "date",
                schema: "medicine_store",
                table: "cart_details",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
