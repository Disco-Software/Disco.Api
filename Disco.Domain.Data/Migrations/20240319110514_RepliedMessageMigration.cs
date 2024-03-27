using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    public partial class RepliedMessageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketMessages");

            migrationBuilder.AddColumn<int>(
                name: "RepliedMessageId",
                table: "TicketMessages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessages_RepliedMessageId",
                table: "TicketMessages",
                column: "RepliedMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessages_TicketMessages_RepliedMessageId",
                table: "TicketMessages",
                column: "RepliedMessageId",
                principalTable: "TicketMessages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessages_TicketMessages_RepliedMessageId",
                table: "TicketMessages");

            migrationBuilder.DropIndex(
                name: "IX_TicketMessages_RepliedMessageId",
                table: "TicketMessages");

            migrationBuilder.DropColumn(
                name: "RepliedMessageId",
                table: "TicketMessages");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
