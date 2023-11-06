using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyActivity.WebMvc.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonName = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonPicture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "activiesDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<string>(type: "TEXT", nullable: true),
                    DayOfWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelPersonFamilyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activiesDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activiesDays_personFamilies_ModelPersonFamilyId",
                        column: x => x.ModelPersonFamilyId,
                        principalTable: "personFamilies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "personFamilies",
                columns: new[] { "Id", "PersonName", "PersonPicture" },
                values: new object[] { 1, 1, "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" });

            migrationBuilder.CreateIndex(
                name: "IX_activiesDays_ModelPersonFamilyId",
                table: "activiesDays",
                column: "ModelPersonFamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activiesDays");

            migrationBuilder.DropTable(
                name: "personFamilies");
        }
    }
}
