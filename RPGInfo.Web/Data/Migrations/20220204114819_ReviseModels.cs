using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGInfo.Web.Data.Migrations
{
    public partial class ReviseModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Campaigns_AreaCampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AreasOfInterest_AreaOfInterestId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_CampaignEvent_CampaignEventId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AreasOfInterest");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AreasOfInterest");

            migrationBuilder.RenameColumn(
                name: "CampaignEventId",
                table: "Notes",
                newName: "WorldEventId");

            migrationBuilder.RenameColumn(
                name: "AreaOfInterestId",
                table: "Notes",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_CampaignEventId",
                table: "Notes",
                newName: "IX_Notes_WorldEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AreaOfInterestId",
                table: "Notes",
                newName: "IX_Notes_AreaId");

            migrationBuilder.RenameColumn(
                name: "EventTitle",
                table: "CampaignEvent",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "AreaCampaignId",
                table: "AreasOfInterest",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_AreasOfInterest_AreaCampaignId",
                table: "AreasOfInterest",
                newName: "IX_AreasOfInterest_CampaignId");

            migrationBuilder.AddColumn<int>(
                name: "WorldEventId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "CampaignEvent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventLocationId",
                table: "CampaignEvent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WorldEventId",
                table: "Characters",
                column: "WorldEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEvent_EventLocationId",
                table: "CampaignEvent",
                column: "EventLocationId");

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
                name: "FK_Characters_CampaignEvent_WorldEventId",
                table: "Characters",
                column: "WorldEventId",
                principalTable: "CampaignEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AreasOfInterest_AreaId",
                table: "Notes",
                column: "AreaId",
                principalTable: "AreasOfInterest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_CampaignEvent_WorldEventId",
                table: "Notes",
                column: "WorldEventId",
                principalTable: "CampaignEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_Campaigns_CampaignId",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignEvent_AreasOfInterest_EventLocationId",
                table: "CampaignEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CampaignEvent_WorldEventId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AreasOfInterest_AreaId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_CampaignEvent_WorldEventId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_WorldEventId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_CampaignEvent_EventLocationId",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "WorldEventId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "CampaignEvent");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "CampaignEvent");

            migrationBuilder.RenameColumn(
                name: "WorldEventId",
                table: "Notes",
                newName: "CampaignEventId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Notes",
                newName: "AreaOfInterestId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_WorldEventId",
                table: "Notes",
                newName: "IX_Notes_CampaignEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AreaId",
                table: "Notes",
                newName: "IX_Notes_AreaOfInterestId");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "CampaignEvent",
                newName: "EventTitle");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "AreasOfInterest",
                newName: "AreaCampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_AreasOfInterest_CampaignId",
                table: "AreasOfInterest",
                newName: "IX_AreasOfInterest_AreaCampaignId");

            migrationBuilder.AddColumn<int>(
                name: "NoteType",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Campaigns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Campaigns",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Campaigns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Campaigns",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CampaignEvent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "CampaignEvent",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "CampaignEvent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "CampaignEvent",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AreasOfInterest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "AreasOfInterest",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AreasOfInterest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "AreasOfInterest",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_Campaigns_AreaCampaignId",
                table: "AreasOfInterest",
                column: "AreaCampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AreasOfInterest_AreaOfInterestId",
                table: "Notes",
                column: "AreaOfInterestId",
                principalTable: "AreasOfInterest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_CampaignEvent_CampaignEventId",
                table: "Notes",
                column: "CampaignEventId",
                principalTable: "CampaignEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
