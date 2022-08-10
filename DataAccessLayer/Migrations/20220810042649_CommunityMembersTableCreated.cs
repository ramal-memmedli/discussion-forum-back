using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CommunityMembersTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTopic_Community_CommunityId",
                table: "CommunityTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTopic_Topics_TopicId",
                table: "CommunityTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunityTopic",
                table: "CommunityTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Community",
                table: "Community");

            migrationBuilder.RenameTable(
                name: "CommunityTopic",
                newName: "CommunityTopics");

            migrationBuilder.RenameTable(
                name: "Community",
                newName: "Communities");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityTopic_TopicId",
                table: "CommunityTopics",
                newName: "IX_CommunityTopics_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityTopic_CommunityId",
                table: "CommunityTopics",
                newName: "IX_CommunityTopics_CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunityTopics",
                table: "CommunityTopics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communities",
                table: "Communities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommunityMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityMembers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommunityMembers_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMembers_AppUserId",
                table: "CommunityMembers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMembers_CommunityId",
                table: "CommunityMembers",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTopics_Communities_CommunityId",
                table: "CommunityTopics",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTopics_Topics_TopicId",
                table: "CommunityTopics",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTopics_Communities_CommunityId",
                table: "CommunityTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTopics_Topics_TopicId",
                table: "CommunityTopics");

            migrationBuilder.DropTable(
                name: "CommunityMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunityTopics",
                table: "CommunityTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communities",
                table: "Communities");

            migrationBuilder.RenameTable(
                name: "CommunityTopics",
                newName: "CommunityTopic");

            migrationBuilder.RenameTable(
                name: "Communities",
                newName: "Community");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityTopics_TopicId",
                table: "CommunityTopic",
                newName: "IX_CommunityTopic_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityTopics_CommunityId",
                table: "CommunityTopic",
                newName: "IX_CommunityTopic_CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunityTopic",
                table: "CommunityTopic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Community",
                table: "Community",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTopic_Community_CommunityId",
                table: "CommunityTopic",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTopic_Topics_TopicId",
                table: "CommunityTopic",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
