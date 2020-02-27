using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingApp.Migrations
{
    public partial class Mothi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_Accounts_AccountUserName1",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_CartEntries_CartEntryItemId",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_Accounts_UserName",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_orderdetails_OrderId",
                table: "OrderedItems");

            migrationBuilder.DropIndex(
                name: "IX_orderdetails_AccountUserName1",
                table: "orderdetails");

            migrationBuilder.DropIndex(
                name: "IX_orderdetails_CartEntryItemId",
                table: "orderdetails");

            migrationBuilder.DropColumn(
                name: "AccountUserName1",
                table: "orderdetails");

            migrationBuilder.DropColumn(
                name: "CartEntryItemId",
                table: "orderdetails");

            migrationBuilder.RenameTable(
                name: "orderdetails",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_orderdetails_UserName",
                table: "OrderDetails",
                newName: "IX_OrderDetails_UserName");

            migrationBuilder.AddColumn<string>(
                name: "AccountUserName",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderedItemItemId",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AccountUserName",
                table: "OrderDetails",
                column: "AccountUserName");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderedItemItemId",
                table: "OrderDetails",
                column: "OrderedItemItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Accounts_AccountUserName",
                table: "OrderDetails",
                column: "AccountUserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderedItems_OrderedItemItemId",
                table: "OrderDetails",
                column: "OrderedItemItemId",
                principalTable: "OrderedItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Accounts_UserName",
                table: "OrderDetails",
                column: "UserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_OrderDetails_OrderId",
                table: "OrderedItems",
                column: "OrderId",
                principalTable: "OrderDetails",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Accounts_AccountUserName",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderedItems_OrderedItemItemId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Accounts_UserName",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_OrderDetails_OrderId",
                table: "OrderedItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_AccountUserName",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderedItemItemId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "AccountUserName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderedItemItemId",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "orderdetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_UserName",
                table: "orderdetails",
                newName: "IX_orderdetails_UserName");

            migrationBuilder.AddColumn<string>(
                name: "AccountUserName1",
                table: "orderdetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartEntryItemId",
                table: "orderdetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_AccountUserName1",
                table: "orderdetails",
                column: "AccountUserName1");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_CartEntryItemId",
                table: "orderdetails",
                column: "CartEntryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_Accounts_AccountUserName1",
                table: "orderdetails",
                column: "AccountUserName1",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_CartEntries_CartEntryItemId",
                table: "orderdetails",
                column: "CartEntryItemId",
                principalTable: "CartEntries",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_Accounts_UserName",
                table: "orderdetails",
                column: "UserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_orderdetails_OrderId",
                table: "OrderedItems",
                column: "OrderId",
                principalTable: "orderdetails",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
