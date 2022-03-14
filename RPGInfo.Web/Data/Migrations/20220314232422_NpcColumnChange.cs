using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class NpcColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RelatedNpcs",
                newName: "Relationship");

            migrationBuilder.RenameColumn(
                name: "Backstory",
                table: "RelatedNpcs",
                newName: "Background");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Relationship",
                table: "RelatedNpcs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Background",
                table: "RelatedNpcs",
                newName: "Backstory");
        }
    }
}
