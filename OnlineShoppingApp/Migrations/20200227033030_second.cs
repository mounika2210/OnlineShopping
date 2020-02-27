using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "cart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_UserName",
                table: "cart",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_Accounts_UserName",
                table: "cart",
                column: "UserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_Accounts_UserName",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_UserName",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "cart");
        }
    }
}
