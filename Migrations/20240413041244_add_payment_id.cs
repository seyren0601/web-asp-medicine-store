using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine_Store.Migrations
{
    /// <inheritdoc />
    public partial class add_payment_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                schema: "medicine_store",
                table: "don_hang",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentID",
                schema: "medicine_store",
                table: "don_hang",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDate",
                schema: "medicine_store",
                table: "don_hang");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                schema: "medicine_store",
                table: "don_hang");
        }
    }
}
