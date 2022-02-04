using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Campaigns_CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignEvent_AreasOfInterest_EventLocationId",
                table: "CampaignEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignEvent_Campaigns_CampaignId",
                table: "CampaignEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CampaignEvent_WorldEventId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Campaigns_CampaignId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_CampaignEvent_WorldEventId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Campaigns_CampaignId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CampaignId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CampaignId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_AreasOfInterest_CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampaignEvent",
                table: "CampaignEvent");

            migrationBuilder.DropIndex(
                name: "IX_CampaignEvent_CampaignId",
                table: "CampaignEvent");

            migrationBuilder.DropIndex(
                name: "IX_CampaignEvent_EventLocationId",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "CampaignEvent");

            migrationBuilder.RenameTable(
                name: "CampaignEvent",
                newName: "WorldEvents");

            migrationBuilder.RenameColumn(
                name: "WorldEventId",
                table: "Characters",
                newName: "CharacterId");

            migrationBuilder.RenameColumn(
                name: "CurrentLocation",
                table: "Characters",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_WorldEventId",
                table: "Characters",
                newName: "IX_Characters_CharacterId");

            migrationBuilder.AddColumn<string>(
                name: "Backstory",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorldEvents",
                table: "WorldEvents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AreaCharacter",
                columns: table => new
                {
                    AreaCharactersId = table.Column<int>(type: "int", nullable: false),
                    KnownAreasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCharacter", x => new { x.AreaCharactersId, x.KnownAreasId });
                    table.ForeignKey(
                        name: "FK_AreaCharacter_AreasOfInterest_KnownAreasId",
                        column: x => x.KnownAreasId,
                        principalTable: "AreasOfInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaCharacter_Characters_AreaCharactersId",
                        column: x => x.AreaCharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaWorldEvent",
                columns: table => new
                {
                    AreaEventsId = table.Column<int>(type: "int", nullable: false),
                    EventLocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaWorldEvent", x => new { x.AreaEventsId, x.EventLocationsId });
                    table.ForeignKey(
                        name: "FK_AreaWorldEvent_AreasOfInterest_EventLocationsId",
                        column: x => x.EventLocationsId,
                        principalTable: "AreasOfInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaWorldEvent_WorldEvents_AreaEventsId",
                        column: x => x.AreaEventsId,
                        principalTable: "WorldEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterWorldEvent",
                columns: table => new
                {
                    CharacterEventsId = table.Column<int>(type: "int", nullable: false),
                    EventCharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterWorldEvent", x => new { x.CharacterEventsId, x.EventCharactersId });
                    table.ForeignKey(
                        name: "FK_CharacterWorldEvent_Characters_EventCharactersId",
                        column: x => x.EventCharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterWorldEvent_WorldEvents_CharacterEventsId",
                        column: x => x.CharacterEventsId,
                        principalTable: "WorldEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaCharacter_KnownAreasId",
                table: "AreaCharacter",
                column: "KnownAreasId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaWorldEvent_EventLocationsId",
                table: "AreaWorldEvent",
                column: "EventLocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterWorldEvent_EventCharactersId",
                table: "CharacterWorldEvent",
                column: "EventCharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_WorldEvents_WorldEventId",
                table: "Notes",
                column: "WorldEventId",
                principalTable: "WorldEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Characters_CharacterId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_WorldEvents_WorldEventId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "AreaCharacter");

            migrationBuilder.DropTable(
                name: "AreaWorldEvent");

            migrationBuilder.DropTable(
                name: "CharacterWorldEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorldEvents",
                table: "WorldEvents");

            migrationBuilder.DropColumn(
                name: "Backstory",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "WorldEvents",
                newName: "CampaignEvent");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Characters",
                newName: "CurrentLocation");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Characters",
                newName: "WorldEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters",
                newName: "IX_Characters_WorldEventId");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Characters",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Characters",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "AreasOfInterest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "CampaignEvent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventLocationId",
                table: "CampaignEvent",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampaignEvent",
                table: "CampaignEvent",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCharacter",
                columns: table => new
                {
                    OthersWhoCharacterKnowsId = table.Column<int>(type: "int", nullable: false),
                    OthersWhoKnowCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCharacter", x => new { x.OthersWhoCharacterKnowsId, x.OthersWhoKnowCharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterCharacter_Characters_OthersWhoCharacterKnowsId",
                        column: x => x.OthersWhoCharacterKnowsId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterCharacter_Characters_OthersWhoKnowCharacterId",
                        column: x => x.OthersWhoKnowCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CampaignId",
                table: "Notes",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CampaignId",
                table: "Characters",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasOfInterest_CampaignId",
                table: "AreasOfInterest",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEvent_CampaignId",
                table: "CampaignEvent",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEvent_EventLocationId",
                table: "CampaignEvent",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCharacter_OthersWhoKnowCharacterId",
                table: "CharacterCharacter",
                column: "OthersWhoKnowCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_Campaigns_CampaignId",
                table: "AreasOfInterest",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignEvent_AreasOfInterest_EventLocationId",
                table: "CampaignEvent",
                column: "EventLocationId",
                principalTable: "AreasOfInterest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignEvent_Campaigns_CampaignId",
                table: "CampaignEvent",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CampaignEvent_WorldEventId",
                table: "Characters",
                column: "WorldEventId",
                principalTable: "CampaignEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Campaigns_CampaignId",
                table: "Characters",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_CampaignEvent_WorldEventId",
                table: "Notes",
                column: "WorldEventId",
                principalTable: "CampaignEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Campaigns_CampaignId",
                table: "Notes",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
