using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class ModelRedesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Campaigns_CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Settings_SettingId",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Settings_SettingId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AreasOfInterest_AreaOfInterestId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Parties_PartyId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Settings_SettingId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Parties_PartyId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Settings_SettingId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Notes_PartyId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_SettingId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AreaOfInterestId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PartyId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SettingId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_SettingId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_AreasOfInterest_CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "AreaOfInterestId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.RenameColumn(
                name: "SettingId",
                table: "AreasOfInterest",
                newName: "AreaCampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_AreasOfInterest_SettingId",
                table: "AreasOfInterest",
                newName: "IX_AreasOfInterest_AreaCampaignId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_Campaigns_AreaCampaignId",
                table: "AreasOfInterest",
                column: "AreaCampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Campaigns_AreaCampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "AreaCampaignId",
                table: "AreasOfInterest",
                newName: "SettingId");

            migrationBuilder.RenameIndex(
                name: "IX_AreasOfInterest_AreaCampaignId",
                table: "AreasOfInterest",
                newName: "IX_AreasOfInterest_SettingId");

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaOfInterestId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "Campaigns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "AreasOfInterest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PartyId",
                table: "Notes",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SettingId",
                table: "Notes",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AreaOfInterestId",
                table: "Characters",
                column: "AreaOfInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PartyId",
                table: "Characters",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SettingId",
                table: "Characters",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_SettingId",
                table: "Campaigns",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasOfInterest_CampaignId",
                table: "AreasOfInterest",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_CampaignId",
                table: "Parties",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_PartyId",
                table: "Settings",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_Campaigns_CampaignId",
                table: "AreasOfInterest",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_Settings_SettingId",
                table: "AreasOfInterest",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Settings_SettingId",
                table: "Campaigns",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AreasOfInterest_AreaOfInterestId",
                table: "Characters",
                column: "AreaOfInterestId",
                principalTable: "AreasOfInterest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Parties_PartyId",
                table: "Characters",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Settings_SettingId",
                table: "Characters",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Parties_PartyId",
                table: "Notes",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Settings_SettingId",
                table: "Notes",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
