using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAccountStatusIndexMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus");

            migrationBuilder.DropColumn(
                name: "AccountStatusId",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus");

            migrationBuilder.AddColumn<int>(
                name: "AccountStatusId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
