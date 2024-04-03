using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sacrament_Meeting_Planner.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Presiding = table.Column<string>(type: "TEXT", nullable: true),
                    Conducting = table.Column<string>(type: "TEXT", nullable: true),
                    OpeningHymn = table.Column<int>(type: "INTEGER", nullable: false),
                    Invocation = table.Column<string>(type: "TEXT", nullable: true),
                    SacramentHymn = table.Column<int>(type: "INTEGER", nullable: false),
                    IntermediateHymn = table.Column<int>(type: "INTEGER", nullable: false),
                    ClosingHymn = table.Column<int>(type: "INTEGER", nullable: false),
                    Benediction = table.Column<string>(type: "TEXT", nullable: true),
                    SpeakerSubject = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_MeetingId",
                table: "Speakers",
                column: "MeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
