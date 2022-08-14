using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class TopicAnswerRelationChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicAnswers");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TopicId",
                table: "Answers",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Topics_TopicId",
                table: "Answers",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Topics_TopicId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_TopicId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "TopicAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicAnswers_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicAnswers_AnswerId",
                table: "TopicAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicAnswers_TopicId",
                table: "TopicAnswers",
                column: "TopicId");
        }
    }
}
