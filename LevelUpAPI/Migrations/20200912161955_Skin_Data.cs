using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class Skin_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"INSERT INTO [dbo].[skins]
            ([name], [level_min])
        VALUES
            ('man_default', 0),
            ('woman_default', 0),
            ('man_pyjama', NULL),
            ('woman_pyjama', NULL),
            ('man_fancy', 10),
            ('woman_fancy', 10),
            ('man_cook', 7),
            ('woman_cook', 7),
            ('man_sportive', NULL),
            ('woman_sportive', NULL),
            ('man_funny', 3),
            ('woman_funny', 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"DELETE FROM [dbo].[skins]");
        }
    }
}
