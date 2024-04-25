using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts_AccountId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "OperationalDate",
                table: "ServicePayments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationalDate",
                table: "ServicePayments");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountId",
                table: "Accounts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Accounts_AccountId",
                table: "Accounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
