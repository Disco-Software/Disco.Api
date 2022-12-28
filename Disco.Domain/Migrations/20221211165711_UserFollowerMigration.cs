using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class UserFollowerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Accounts_FollowerAccountId",
                table: "UserFollowers");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Accounts_FollowerAccountId",
                table: "UserFollowers",
                column: "FollowerAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Accounts_FollowerAccountId",
                table: "UserFollowers");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Accounts_FollowerAccountId",
                table: "UserFollowers",
                column: "FollowerAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
