using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FamilyActivity.WebMvc.Migrations.PostgreSql
{
    public partial class InitialDbPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonName = table.Column<int>(type: "integer", nullable: false),
                    PersonPicture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PictureActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityName = table.Column<int>(type: "integer", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActiviesDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    ModelPersonFamilyId = table.Column<int>(type: "integer", nullable: true),
                    ModelPictureActivityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiviesDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiviesDays_PersonFamilies_ModelPersonFamilyId",
                        column: x => x.ModelPersonFamilyId,
                        principalTable: "PersonFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActiviesDays_PictureActivities_ModelPictureActivityId",
                        column: x => x.ModelPictureActivityId,
                        principalTable: "PictureActivities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiviesDays_ModelPersonFamilyId",
                table: "ActiviesDays",
                column: "ModelPersonFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiviesDays_ModelPictureActivityId",
                table: "ActiviesDays",
                column: "ModelPictureActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiviesDays");

            migrationBuilder.DropTable(
                name: "PersonFamilies");

            migrationBuilder.DropTable(
                name: "PictureActivities");
        }
    }
}
