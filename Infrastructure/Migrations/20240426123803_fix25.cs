using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currency_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalAccounts_Currency_CurrencyId",
                table: "ExternalAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequests_Currency_CurrencyId",
                table: "ProductRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Currency_CurrencyId",
                table: "Transfers");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_CurrencyId",
                table: "Accounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalAccounts_Currencies_CurrencyId",
                table: "ExternalAccounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequests_Currencies_CurrencyId",
                table: "ProductRequests",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalAccounts_Currencies_CurrencyId",
                table: "ExternalAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequests_Currencies_CurrencyId",
                table: "ProductRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currency_CurrencyId",
                table: "Accounts",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalAccounts_Currency_CurrencyId",
                table: "ExternalAccounts",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequests_Currency_CurrencyId",
                table: "ProductRequests",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Currency_CurrencyId",
                table: "Transfers",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
