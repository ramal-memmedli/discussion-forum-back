using Microsoft.EntityFrameworkCore.Migrations;

namespace CommuPoint.Persistence.Migrations
{
    public partial class CommunityTableEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Communities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Communities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
