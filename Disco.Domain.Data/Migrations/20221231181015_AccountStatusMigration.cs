using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class AccountStatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountStatuses_StatusId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_StatusId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountStatuses",
                table: "AccountStatuses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "AccountStatuses",
                newName: "AccountStatus");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AccountStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountStatus",
                table: "AccountStatus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowersCount = table.Column<int>(type: "int", nullable: false),
                    NextStatusId = table.Column<int>(type: "int", nullable: false),
                    UserTarget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatus_Accounts_AccountId",
                table: "AccountStatus");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountStatus",
                table: "AccountStatus");

            migrationBuilder.DropIndex(
                name: "IX_AccountStatus_AccountId",
                table: "AccountStatus");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountStatus");

            migrationBuilder.RenameTable(
                name: "AccountStatus",
                newName: "AccountStatuses");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountStatuses",
                table: "AccountStatuses",
                column: "Id");

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
    }
}
