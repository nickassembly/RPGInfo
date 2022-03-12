using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class AddRelatedNpcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Characters_CharacterId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "AreaCharacter");

            migrationBuilder.DropTable(
                name: "CharacterWorldEvent");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "WorldEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "AreasOfInterest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RelatedNpcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Portrait = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Backstory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    WorldEventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedNpcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedNpcs_AreasOfInterest_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreasOfInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedNpcs_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedNpcs_WorldEvents_WorldEventId",
                        column: x => x.WorldEventId,
                        principalTable: "WorldEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorldEvents_CharacterId",
                table: "WorldEvents",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasOfInterest_CharacterId",
                table: "AreasOfInterest",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedNpcs_AreaId",
                table: "RelatedNpcs",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedNpcs_CharacterId",
                table: "RelatedNpcs",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedNpcs_WorldEventId",
                table: "RelatedNpcs",
                column: "WorldEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_Characters_CharacterId",
                table: "AreasOfInterest",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorldEvents_Characters_CharacterId",
                table: "WorldEvents",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Characters_CharacterId",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldEvents_Characters_CharacterId",
                table: "WorldEvents");

            migrationBuilder.DropTable(
                name: "RelatedNpcs");

            migrationBuilder.DropIndex(
                name: "IX_WorldEvents_CharacterId",
                table: "WorldEvents");

            migrationBuilder.DropIndex(
                name: "IX_AreasOfInterest_CharacterId",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "WorldEvents");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "AreasOfInterest");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Characters",
                type: "int",
                nullable: true);

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
                name: "IX_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaCharacter_KnownAreasId",
                table: "AreaCharacter",
                column: "KnownAreasId");

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
        }
    }
}
