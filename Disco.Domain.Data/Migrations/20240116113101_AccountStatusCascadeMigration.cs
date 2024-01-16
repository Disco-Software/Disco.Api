using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    public partial class AccountStatusCascadeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatuses_Accounts_AccountId",
                table: "AccountStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatuses_Accounts_AccountId",
                table: "AccountStatuses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatuses_Accounts_AccountId",
                table: "AccountStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatuses_Accounts_AccountId",
                table: "AccountStatuses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
