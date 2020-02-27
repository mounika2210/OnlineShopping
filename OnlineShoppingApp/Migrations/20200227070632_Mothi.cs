using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingApp.Migrations
{
    public partial class Mothi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_carts_OrderId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "carts");

            migrationBuilder.RenameTable(
                name: "carts",
                newName: "CartEntries");

            migrationBuilder.RenameIndex(
                name: "IX_carts_UserName",
                table: "CartEntries",
                newName: "IX_CartEntries_UserName");

            migrationBuilder.CreateTable(
                name: "OrderedItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItemId", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_OrderedItems_orderdetails_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orderdetails",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Accounts_UserName",
                        column: x => x.UserName,
                        principalTable: "Accounts",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_OrderId",
                table: "OrderedItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_UserName",
                table: "OrderedItems",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_CartEntries_Accounts_UserName",
                table: "CartEntries",
                column: "UserName",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartEntries_Accounts_UserName",
                table: "CartEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_CartEntries_CartEntryItemId",
                table: "orderdetails");

            migrationBuilder.DropTable(
                name: "OrderedItems");

            migrationBuilder.RenameTable(
                name: "CartEntries",
                newName: "carts");

            migrationBuilder.RenameIndex(
                name: "IX_CartEntries_UserName",
                table: "carts",
                newName: "IX_carts_UserName");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_carts_OrderId",
                table: "carts",
                column: "OrderId");

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
    }
}
