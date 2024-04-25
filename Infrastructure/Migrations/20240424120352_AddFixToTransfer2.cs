using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFixToTransfer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLimits_Accounts_AccountId",
                table: "TransactionLimits");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "TransactionLimits",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionLimits_AccountId",
                table: "TransactionLimits",
                newName: "IX_TransactionLimits_SenderId");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "TransactionLimits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLimits_ReceiverId",
                table: "TransactionLimits",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLimits_Accounts_ReceiverId",
                table: "TransactionLimits",
                column: "ReceiverId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLimits_Accounts_SenderId",
                table: "TransactionLimits",
                column: "SenderId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLimits_Accounts_ReceiverId",
                table: "TransactionLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLimits_Accounts_SenderId",
                table: "TransactionLimits");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLimits_ReceiverId",
                table: "TransactionLimits");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "TransactionLimits");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "TransactionLimits",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionLimits_SenderId",
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
    }
}
