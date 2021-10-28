using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.DAL.Migrations
{
    public partial class AddListsOnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostImages_PostImageId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostSongs_SongId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostVideos_VideoId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SongId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VideoId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PostVideos_PostId",
                table: "PostVideos",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSongs_PostId",
                table: "PostSongs",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostSongs_Posts_PostId",
                table: "PostSongs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostVideos_Posts_PostId",
                table: "PostVideos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PostSongs_Posts_PostId",
                table: "PostSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostVideos_Posts_PostId",
                table: "PostVideos");

            migrationBuilder.DropIndex(
                name: "IX_PostVideos_PostId",
                table: "PostVideos");

            migrationBuilder.DropIndex(
                name: "IX_PostSongs_PostId",
                table: "PostSongs");

            migrationBuilder.DropIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostSongs");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostImageId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostImageId",
                table: "Posts",
                column: "PostImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SongId",
                table: "Posts",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VideoId",
                table: "Posts",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostImages_PostImageId",
                table: "Posts",
                column: "PostImageId",
                principalTable: "PostImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
        }
    }
}
