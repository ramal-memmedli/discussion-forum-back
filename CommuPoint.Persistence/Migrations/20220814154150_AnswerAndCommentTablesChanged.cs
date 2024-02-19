using Microsoft.EntityFrameworkCore.Migrations;

namespace CommuPoint.Persistence.Migrations
{
    public partial class AnswerAndCommentTablesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AppUserId",
                table: "Answers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_AppUserId",
                table: "Answers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_AppUserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Answers_AppUserId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Answers");
        }
    }
}
