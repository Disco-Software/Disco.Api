using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class LikeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AccountId",
                table: "Likes",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Accounts_AccountId",
                table: "Likes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Accounts_AccountId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_AccountId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Likes");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
