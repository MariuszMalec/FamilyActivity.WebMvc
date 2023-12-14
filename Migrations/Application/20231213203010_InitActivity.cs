using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyActivity.WebMvc.Migrations.Application
{
    public partial class InitActivity : Migration
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
                name: "pictureActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityName = table.Column<int>(type: "INTEGER", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pictureActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "activiesDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DayOfWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelPersonFamilyId = table.Column<int>(type: "INTEGER", nullable: true),
                    ModelPictureActivityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activiesDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activiesDays_personFamilies_ModelPersonFamilyId",
                        column: x => x.ModelPersonFamilyId,
                        principalTable: "personFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_activiesDays_pictureActivities_ModelPictureActivityId",
                        column: x => x.ModelPictureActivityId,
                        principalTable: "pictureActivities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_activiesDays_ModelPersonFamilyId",
                table: "activiesDays",
                column: "ModelPersonFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_activiesDays_ModelPictureActivityId",
                table: "activiesDays",
                column: "ModelPictureActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activiesDays");

            migrationBuilder.DropTable(
                name: "personFamilies");

            migrationBuilder.DropTable(
                name: "pictureActivities");
        }
    }
}
