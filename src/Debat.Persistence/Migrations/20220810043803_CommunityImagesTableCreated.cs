using Microsoft.EntityFrameworkCore.Migrations;

namespace Debat.Persistence.Migrations
{
    public partial class CommunityImagesTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Target = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityImages_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityImages_CommunityId",
                table: "CommunityImages",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityImages_ImageId",
                table: "CommunityImages",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityImages");
        }
    }
}
