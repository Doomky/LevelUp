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
            ('man_pyjama', 0),
            ('woman_pyjama', 0),
            ('man_fancy', 0),
            ('woman_fancy', 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"DELETE FROM [dbo].[skins]");
        }
    }
}
