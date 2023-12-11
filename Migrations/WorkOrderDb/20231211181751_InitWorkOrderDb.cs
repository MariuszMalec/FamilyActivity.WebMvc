using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyActivity.WebMvc.Migrations.WorkOrderDb
{
    public partial class InitWorkOrderDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Ordinal = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdinalPriority = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Group 1" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Group 2" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Group 3" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 1, 1, "Person A" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 2, 1, "Person B" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 3, 1, "Person C" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 4, 2, "Person D" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 5, 2, "Person E" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 6, 2, "Person F" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 7, 3, "Person G" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 8, 3, "Person H" });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_GroupId",
                table: "Resources",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_ResourceId",
                table: "WorkOrders",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
