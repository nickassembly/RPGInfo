using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WorldEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AreasOfInterest",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorldEvents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AreasOfInterest");
        }
    }
}
