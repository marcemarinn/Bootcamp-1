using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_TransactionHistories_TransactionHistoryId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_TransactionHistoryId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "TransactionHistoryId",
                table: "Movements");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");

            migrationBuilder.AddColumn<int>(
                name: "TransactionHistoryId",
                table: "Movements",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movements_TransactionHistoryId",
                table: "Movements",
                column: "TransactionHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_TransactionHistories_TransactionHistoryId",
                table: "Movements",
                column: "TransactionHistoryId",
                principalTable: "TransactionHistories",
                principalColumn: "Id");
        }
    }
}
