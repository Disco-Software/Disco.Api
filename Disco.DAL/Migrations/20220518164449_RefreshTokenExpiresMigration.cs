using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.DAL.Migrations
{
    public partial class RefreshTokenExpiresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiress",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiress",
                table: "AspNetUsers");
        }
    }
}
