using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApp.Migrations
{
    /// <inheritdoc />
    public partial class TweetLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "TweetsLike",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetsLike_UserId",
                table: "TweetsLike",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetsLike_Users_UserId",
                table: "TweetsLike",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetsLike_Users_UserId",
                table: "TweetsLike");

            migrationBuilder.DropIndex(
                name: "IX_TweetsLike_UserId",
                table: "TweetsLike");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TweetsLike",
                newName: "User_id");
        }
    }
}
