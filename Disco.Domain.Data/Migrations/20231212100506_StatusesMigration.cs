using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    public partial class StatusesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountStatus",
                table: "AccountStatus");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "AccountStatus",
                newName: "AccountStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_AccountStatus_AccountId",
                table: "AccountStatuses",
                newName: "IX_AccountStatuses_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountStatuses",
                table: "AccountStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatuses_Accounts_AccountId",
                table: "AccountStatuses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatuses_Accounts_AccountId",
                table: "AccountStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountStatuses",
                table: "AccountStatuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.RenameTable(
                name: "AccountStatuses",
                newName: "AccountStatus");

            migrationBuilder.RenameIndex(
                name: "IX_AccountStatuses_AccountId",
                table: "AccountStatus",
                newName: "IX_AccountStatus_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountStatus",
                table: "AccountStatus",
                column: "Id");

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
