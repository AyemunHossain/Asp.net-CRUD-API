using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Project 1" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Project 2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 1, null, null, null, 1, null, "Bug 1" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 2, null, null, null, 2, null, "Bug 2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 3, null, null, null, 2, null, "Bug 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
