using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine_Store.Migrations
{
    /// <inheritdoc />
    public partial class fixed_cart_details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "thuoc_id",
                schema: "medicine_store",
                table: "cart_details",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "thuoc_id",
                schema: "medicine_store",
                table: "cart_details",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
