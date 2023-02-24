using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class SignalRConnectionMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connection_Accounts_AccountId",
                table: "Connection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connection",
                table: "Connection");

            migrationBuilder.RenameTable(
                name: "Connection",
                newName: "Connections");

            migrationBuilder.RenameIndex(
                name: "IX_Connection_AccountId",
                table: "Connections",
                newName: "IX_Connections_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connections",
                table: "Connections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Accounts_AccountId",
                table: "Connections",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Accounts_AccountId",
                table: "Connections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connections",
                table: "Connections");

            migrationBuilder.RenameTable(
                name: "Connections",
                newName: "Connection");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_AccountId",
                table: "Connection",
                newName: "IX_Connection_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connection",
                table: "Connection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Connection_Accounts_AccountId",
                table: "Connection",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
