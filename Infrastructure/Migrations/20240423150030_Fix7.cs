using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovementId",
                table: "TransactionHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistories_MovementId",
                table: "TransactionHistories",
                column: "MovementId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Movements_MovementId",
                table: "TransactionHistories",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Movements_MovementId",
                table: "TransactionHistories");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistories_MovementId",
                table: "TransactionHistories");

            migrationBuilder.DropColumn(
                name: "MovementId",
                table: "TransactionHistories");
        }
    }
}
