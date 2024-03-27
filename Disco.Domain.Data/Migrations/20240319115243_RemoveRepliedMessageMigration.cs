using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    public partial class RemoveRepliedMessageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
