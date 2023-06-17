using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homies.Data.Migrations
{
    public partial class AddDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_AspNetUsers_HelperId",
                table: "EventParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Events_EventId",
                table: "EventParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipant",
                table: "EventParticipant");

            migrationBuilder.RenameTable(
                name: "EventParticipant",
                newName: "EventParticipants");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipant_HelperId",
                table: "EventParticipants",
                newName: "IX_EventParticipants_HelperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants",
                columns: new[] { "EventId", "HelperId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_AspNetUsers_HelperId",
                table: "EventParticipants",
                column: "HelperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_AspNetUsers_HelperId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants");

            migrationBuilder.RenameTable(
                name: "EventParticipants",
                newName: "EventParticipant");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_HelperId",
                table: "EventParticipant",
                newName: "IX_EventParticipant_HelperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipant",
                table: "EventParticipant",
                columns: new[] { "EventId", "HelperId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_AspNetUsers_HelperId",
                table: "EventParticipant",
                column: "HelperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Events_EventId",
                table: "EventParticipant",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
