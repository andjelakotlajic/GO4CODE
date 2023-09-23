using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApp.Migrations
{
    /// <inheritdoc />
    public partial class userIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetsLike_Users_UserId",
                table: "TweetsLike");

            migrationBuilder.DropIndex(
                name: "IX_TweetsLike_UserId",
                table: "TweetsLike");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.NoAction);
        }
    }
}
