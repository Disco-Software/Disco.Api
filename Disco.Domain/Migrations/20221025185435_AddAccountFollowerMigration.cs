using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class AddAccountFollowerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Account_AccountFollowerId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Account_UserAccountId",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_AccountFollowerId",
                table: "UserFollowers");

            migrationBuilder.DropColumn(
                name: "AccountFollowerId",
                table: "UserFollowers");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "UserFollowers");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "UserFollowers",
                newName: "FollowingAccountId");

            migrationBuilder.RenameColumn(
                name: "IsFriend",
                table: "UserFollowers",
                newName: "IsFollowing");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "UserFollowers",
                newName: "FollowerAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowers_UserAccountId",
                table: "UserFollowers",
                newName: "IX_UserFollowers_FollowingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowerAccountId",
                table: "UserFollowers",
                column: "FollowerAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Account_FollowerAccountId",
                table: "UserFollowers",
                column: "FollowerAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Account_FollowingAccountId",
                table: "UserFollowers",
                column: "FollowingAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Account_FollowerAccountId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Account_FollowingAccountId",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_FollowerAccountId",
                table: "UserFollowers");

            migrationBuilder.RenameColumn(
                name: "IsFollowing",
                table: "UserFollowers",
                newName: "IsFriend");

            migrationBuilder.RenameColumn(
                name: "FollowingAccountId",
                table: "UserFollowers",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "FollowerAccountId",
                table: "UserFollowers",
                newName: "FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowers_FollowingAccountId",
                table: "UserFollowers",
                newName: "IX_UserFollowers_UserAccountId");

            migrationBuilder.AddColumn<int>(
                name: "AccountFollowerId",
                table: "UserFollowers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "UserFollowers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_AccountFollowerId",
                table: "UserFollowers",
                column: "AccountFollowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Account_AccountFollowerId",
                table: "UserFollowers",
                column: "AccountFollowerId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Account_UserAccountId",
                table: "UserFollowers",
                column: "UserAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
