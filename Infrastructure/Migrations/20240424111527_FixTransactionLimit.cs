using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionLimit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLimits_Accounts_DestinationAccountId",
                table: "TransactionLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLimits_Accounts_OriginAccountId",
                table: "TransactionLimits");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLimits_DestinationAccountId",
                table: "TransactionLimits");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                table: "TransactionLimits");

            migrationBuilder.RenameColumn(
                name: "OriginAccountId",
                table: "TransactionLimits",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionLimits_OriginAccountId",
                table: "TransactionLimits",
                newName: "IX_TransactionLimits_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLimits_Accounts_AccountId",
                table: "TransactionLimits",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLimits_Accounts_AccountId",
                table: "TransactionLimits");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "TransactionLimits",
                newName: "OriginAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionLimits_AccountId",
                table: "TransactionLimits",
                newName: "IX_TransactionLimits_OriginAccountId");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccountId",
                table: "TransactionLimits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLimits_DestinationAccountId",
                table: "TransactionLimits",
                column: "DestinationAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLimits_Accounts_DestinationAccountId",
                table: "TransactionLimits",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLimits_Accounts_OriginAccountId",
                table: "TransactionLimits",
                column: "OriginAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
