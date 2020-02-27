using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingApp.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    CartEntryItemId = table.Column<int>(nullable: true),
                    DeliveryAddress = table.Column<string>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    AccountUserName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderId", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemId", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_cart_orderdetails_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orderdetails",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CardNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(nullable: false),
                    CVV = table.Column<int>(nullable: false),
                    ValidDate = table.Column<string>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardNo", x => x.CardNo);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    MobileNo = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    MyPaymentCardNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_Accounts_Payments_MyPaymentCardNo",
                        column: x => x.MyPaymentCardNo,
                        principalTable: "Payments",
                        principalColumn: "CardNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MyPaymentCardNo",
                table: "Accounts",
                column: "MyPaymentCardNo");

            migrationBuilder.CreateIndex(
                name: "IX_cart_OrderId",
                table: "cart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_AccountUserName1",
                table: "orderdetails",
                column: "AccountUserName1");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_CartEntryItemId",
                table: "orderdetails",
                column: "CartEntryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_UserName",
                table: "orderdetails",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserName",
                table: "Payments",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_Accounts_AccountUserName1",
                table: "orderdetails",
                column: "AccountUserName1",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_Accounts_UserName",
                table: "orderdetails",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Accounts_UserName",
                table: "Payments",
                column: "UserName",
                principalTable: "Accounts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Payments_MyPaymentCardNo",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_orderdetails_OrderId",
                table: "cart");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "cart");
        }
    }
}
