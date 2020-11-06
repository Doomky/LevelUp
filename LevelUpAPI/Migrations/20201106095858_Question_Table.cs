using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class Question_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {     
            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    response_a = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    response_b = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    response_c = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    response_d = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    correct_answer = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
