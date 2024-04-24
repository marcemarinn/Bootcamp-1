using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductRequests",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    OriginAccountId = table.Column<int>(type: "integer", nullable: false),
                    DestinationAccountId = table.Column<int>(type: "integer", nullable: false),
                    TransactionalLimit = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TransactionLimit_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLimits_Accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionLimits_Accounts_OriginAccountId",
                        column: x => x.OriginAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLimits_DestinationAccountId",
                table: "TransactionLimits",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLimits_OriginAccountId",
                table: "TransactionLimits",
                column: "OriginAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLimits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductRequests");
        }
    }
}
