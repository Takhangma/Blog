using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWork.Migrations
{
    /// <inheritdoc />
    public partial class Votes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserInfo_PostUserUserId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_PostUserUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PostUserUserId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "PostUser_Name",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostUser_UserId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    VoteUser_UserId = table.Column<int>(type: "int", nullable: false),
                    VoteUser_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUpVote = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Votes_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_BlogId",
                table: "Votes",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropColumn(
                name: "PostUser_Name",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PostUser_UserId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "PostUserUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_PostUserUserId",
                table: "Blogs",
                column: "PostUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserInfo_PostUserUserId",
                table: "Blogs",
                column: "PostUserUserId",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
