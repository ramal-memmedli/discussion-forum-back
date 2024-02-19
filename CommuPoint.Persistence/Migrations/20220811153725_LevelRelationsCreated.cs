using Microsoft.EntityFrameworkCore.Migrations;

namespace CommuPoint.Persistence.Migrations
{
    public partial class LevelRelationsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LevelId",
                table: "AspNetUsers",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Levels_LevelId",
                table: "AspNetUsers",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Levels_LevelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LevelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "AspNetUsers");
        }
    }
}
