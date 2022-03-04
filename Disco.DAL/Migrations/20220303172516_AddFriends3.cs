using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.DAL.Migrations
{
    public partial class AddFriends3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendlyUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_ProfileId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendlyUserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_ProfileId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FriendlyUserId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Friends",
                newName: "ProfileFriendId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Friends",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "Friends",
                newName: "FriendProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserId1",
                table: "Friends",
                newName: "IX_Friends_ProfileFriendId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                newName: "IX_Friends_UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_ProfileFriendId",
                table: "Friends",
                column: "ProfileFriendId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_UserProfileId",
                table: "Friends",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_ProfileFriendId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_UserProfileId",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Friends",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileFriendId",
                table: "Friends",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "FriendProfileId",
                table: "Friends",
                newName: "FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserProfileId",
                table: "Friends",
                newName: "IX_Friends_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_ProfileFriendId",
                table: "Friends",
                newName: "IX_Friends_UserId1");

            migrationBuilder.AddColumn<int>(
                name: "FriendlyUserId",
                table: "Friends",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Friends",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendlyUserId",
                table: "Friends",
                column: "FriendlyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ProfileId",
                table: "Friends",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendlyUserId",
                table: "Friends",
                column: "FriendlyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_ProfileId",
                table: "Friends",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
