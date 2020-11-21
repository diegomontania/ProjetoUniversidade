using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeDiego.Migrations
{
    public partial class IdadeInstrutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Instrutor",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Instrutor");
        }
    }
}
