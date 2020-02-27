using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingApp.Migrations
{
    public partial class Mothi6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Payments_MyPaymentCardNo",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardNo",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_MyPaymentCardNo",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CardNo",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MyPaymentCardNo",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Payments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MyPaymentID",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethodId",
                table: "Payments",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MyPaymentID",
                table: "Accounts",
                column: "MyPaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Payments_MyPaymentID",
                table: "Accounts",
                column: "MyPaymentID",
                principalTable: "Payments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Payments_MyPaymentID",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethodId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_MyPaymentID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MyPaymentID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "CardNo",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MyPaymentCardNo",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardNo",
                table: "Payments",
                column: "CardNo");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MyPaymentCardNo",
                table: "Accounts",
                column: "MyPaymentCardNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Payments_MyPaymentCardNo",
                table: "Accounts",
                column: "MyPaymentCardNo",
                principalTable: "Payments",
                principalColumn: "CardNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
