using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.DAL.Migrations
{
    public partial class SongNamesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PostSongs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PostSongs");
        }
    }
}
