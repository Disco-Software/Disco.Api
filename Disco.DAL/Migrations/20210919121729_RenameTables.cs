using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.DAL.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Songs_SongId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Posts_PostId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Posts_PostId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "PostVideos");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "PostSongs");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_PostId",
                table: "PostVideos",
                newName: "IX_PostVideos_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_PostId",
                table: "PostSongs",
                newName: "IX_PostSongs_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostVideos",
                table: "PostVideos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostSongs",
                table: "PostSongs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostSongs_SongId",
                table: "Posts",
                column: "SongId",
                principalTable: "PostSongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostVideos_VideoId",
                table: "Posts",
                column: "VideoId",
                principalTable: "PostVideos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostSongs_Posts_PostId",
                table: "PostSongs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostVideos_Posts_PostId",
                table: "PostVideos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostSongs_SongId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostVideos_VideoId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostSongs_Posts_PostId",
                table: "PostSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostVideos_Posts_PostId",
                table: "PostVideos");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostVideos",
                table: "PostVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostSongs",
                table: "PostSongs");

            migrationBuilder.RenameTable(
                name: "PostVideos",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "PostSongs",
                newName: "Songs");

            migrationBuilder.RenameIndex(
                name: "IX_PostVideos_PostId",
                table: "Videos",
                newName: "IX_Videos_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostSongs_PostId",
                table: "Songs",
                newName: "IX_Songs_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Songs_SongId",
                table: "Posts",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Posts_PostId",
                table: "Songs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Posts_PostId",
                table: "Videos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
