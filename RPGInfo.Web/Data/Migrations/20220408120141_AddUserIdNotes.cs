using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class AddUserIdNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RelatedNpcs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RelatedNpcs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");
        }
    }
}
