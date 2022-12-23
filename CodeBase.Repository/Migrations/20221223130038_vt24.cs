using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBase.Repository.Migrations
{
    public partial class vt24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustomerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Customers");
        }
    }
}
