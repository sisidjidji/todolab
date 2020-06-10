using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOLAB.Migrations
{
    public partial class AddCreatedByAttributToTabe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ToDoList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ToDoList");
        }
    }
}
