using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApp.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tweets_TweetId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_TweetsLike_Tweets_TweetId",
                table: "TweetsLike");

            migrationBuilder.DropColumn(
                name: "Tweet_id",
                table: "TweetsLike");

            migrationBuilder.AlterColumn<int>(
                name: "TweetId",
                table: "TweetsLike",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TweetId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tweets_TweetId",
                table: "Comments",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TweetsLike_Tweets_TweetId",
                table: "TweetsLike",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tweets_TweetId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_TweetsLike_Tweets_TweetId",
                table: "TweetsLike");

            migrationBuilder.AlterColumn<int>(
                name: "TweetId",
                table: "TweetsLike",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Tweet_id",
                table: "TweetsLike",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TweetId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tweets_TweetId",
                table: "Comments",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetsLike_Tweets_TweetId",
                table: "TweetsLike",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id");
        }
    }
}
