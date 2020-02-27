using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingApp.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_orderdetails_OrderId",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_Accounts_UserName",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_cart_CartEntryItemId",
                table: "orderdetails");

            migrationBuilder.RenameTable(
                name: "cart",
                newName: "carts");

            migrationBuilder.RenameIndex(
                name: "IX_cart_UserName",
                table: "carts",
                newName: "IX_carts_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_cart_OrderId",
                table: "carts",
                newName: "IX_carts_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orderdetails_OrderId",
                table: "carts",
                column: "OrderId",
                principalTable: "orderdetails",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Accounts_UserName",
                table: "carts",
                column: "UserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_carts_CartEntryItemId",
                table: "orderdetails",
                column: "CartEntryItemId",
                principalTable: "carts",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orderdetails_OrderId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_Accounts_UserName",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_carts_CartEntryItemId",
                table: "orderdetails");

            migrationBuilder.RenameTable(
                name: "carts",
                newName: "cart");

            migrationBuilder.RenameIndex(
                name: "IX_carts_UserName",
                table: "cart",
                newName: "IX_cart_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_carts_OrderId",
                table: "cart",
                newName: "IX_cart_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_orderdetails_OrderId",
                table: "cart",
                column: "OrderId",
                principalTable: "orderdetails",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_Accounts_UserName",
                table: "cart",
                column: "UserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_cart_CartEntryItemId",
                table: "orderdetails",
                column: "CartEntryItemId",
                principalTable: "cart",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
