using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProject.Migrations
{
    /// <inheritdoc />
    public partial class Tweet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Followers_userFollowerId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Followers_userFollowerId1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Users_userFollowerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userFollowerId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userFollowerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userFollowerId1",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FollowersId = table.Column<int>(type: "int", nullable: false),
                    FollowingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowersId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingId",
                table: "UserUser",
                column: "FollowingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.AddColumn<int>(
                name: "userFollowerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userFollowerId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_userFollowerId",
                table: "Users",
                column: "userFollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userFollowerId1",
                table: "Users",
                column: "userFollowerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Followers_userFollowerId",
                table: "Users",
                column: "userFollowerId",
                principalTable: "Followers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Followers_userFollowerId1",
                table: "Users",
                column: "userFollowerId1",
                principalTable: "Followers",
                principalColumn: "Id");
        }
    }
}
