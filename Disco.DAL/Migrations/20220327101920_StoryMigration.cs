using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disco.DAL.Migrations
{
    public partial class StoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCreation = table.Column<DateTime>(type: "date", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Stories_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoriesImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoriesImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoriesImages_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryVideos_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ProfileId",
                table: "Stories",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StoriesImages_StoryId",
                table: "StoriesImages",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryVideos_StoryId",
                table: "StoryVideos",
                column: "StoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoriesImages");

            migrationBuilder.DropTable(
                name: "StoryVideos");

            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
