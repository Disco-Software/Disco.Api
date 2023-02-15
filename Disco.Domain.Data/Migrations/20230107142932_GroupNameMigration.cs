using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.Domain.Migrations
{
    public partial class GroupNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroup_Accounts_AccountId",
                table: "AccountGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroup_Group_GroupId",
                table: "AccountGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Group_GroupId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Accounts_AccountId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountGroup",
                table: "AccountGroup");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "AccountGroup",
                newName: "AccountGroups");

            migrationBuilder.RenameIndex(
                name: "IX_Message_GroupId",
                table: "Messages",
                newName: "IX_Messages_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_AccountId",
                table: "Messages",
                newName: "IX_Messages_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountGroup_GroupId",
                table: "AccountGroups",
                newName: "IX_AccountGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountGroup_AccountId",
                table: "AccountGroups",
                newName: "IX_AccountGroups_AccountId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountGroups",
                table: "AccountGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroups_Accounts_AccountId",
                table: "AccountGroups",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroups_Groups_GroupId",
                table: "AccountGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Groups_GroupId",
                table: "Accounts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_AccountId",
                table: "Messages",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroups_Accounts_AccountId",
                table: "AccountGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroups_Groups_GroupId",
                table: "AccountGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Groups_GroupId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_AccountId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountGroups",
                table: "AccountGroups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "AccountGroups",
                newName: "AccountGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupId",
                table: "Message",
                newName: "IX_Message_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_AccountId",
                table: "Message",
                newName: "IX_Message_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountGroups_GroupId",
                table: "AccountGroup",
                newName: "IX_AccountGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountGroups_AccountId",
                table: "AccountGroup",
                newName: "IX_AccountGroup_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountGroup",
                table: "AccountGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroup_Accounts_AccountId",
                table: "AccountGroup",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroup_Group_GroupId",
                table: "AccountGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Group_GroupId",
                table: "Accounts",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Accounts_AccountId",
                table: "Message",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
