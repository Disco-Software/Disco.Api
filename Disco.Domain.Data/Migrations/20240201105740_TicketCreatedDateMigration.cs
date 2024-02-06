using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disco.Domain.Data.Migrations
{
    public partial class TicketCreatedDateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketMessages",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TicketMessages");
        }
    }
}
