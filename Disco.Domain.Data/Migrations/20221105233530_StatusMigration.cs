using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class StatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StatusId",
                table: "Accounts",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountStatuses_StatusId",
                table: "Accounts",
                column: "StatusId",
                principalTable: "AccountStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountStatuses_StatusId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_StatusId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Accounts");
        }
    }
}
