using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sacrament_Meeting_Planner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
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
                    Benediction = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeakerSubject = table.Column<string>(type: "TEXT", nullable: true),
                    Speakers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
