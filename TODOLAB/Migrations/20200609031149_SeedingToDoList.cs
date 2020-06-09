using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOLAB.Migrations
{
    public partial class SeedingToDoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Assignee = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "Id", "Assignee", "DueDate", "Name", "Rating" },
                values: new object[] { 1, "moi", new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sihem", 0 });

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "Id", "Assignee", "DueDate", "Name", "Rating" },
                values: new object[] { 2, "elle", new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "louisa", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoList");
        }
    }
}
