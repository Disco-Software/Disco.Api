using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAccount1StatusIndexMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
