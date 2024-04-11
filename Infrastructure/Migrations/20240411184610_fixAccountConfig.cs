using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixAccountConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Denomination",
                table: "CreditCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CreditCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Denomination",
                table: "CreditCards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CreditCards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts",
                column: "AccountId");
        }
    }
}
