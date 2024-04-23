using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_TransactionHistories_TransactionHistoryId",
                table: "Movements");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionHistoryId",
                table: "Movements",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_TransactionHistories_TransactionHistoryId",
                table: "Movements",
                column: "TransactionHistoryId",
                principalTable: "TransactionHistories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_TransactionHistories_TransactionHistoryId",
                table: "Movements");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionHistoryId",
                table: "Movements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_TransactionHistories_TransactionHistoryId",
                table: "Movements",
                column: "TransactionHistoryId",
                principalTable: "TransactionHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
