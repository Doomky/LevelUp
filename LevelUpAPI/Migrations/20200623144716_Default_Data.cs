using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class Default_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"INSERT INTO [dbo].[categories]
           ([name])
     VALUES
           ('Nutrition'),
		   ('PhysicalActivity'),
		   ('Sleep')");

            migrationBuilder.Sql(
@"INSERT INTO [dbo].[quests_types]
           ([name])
     VALUES
           ('CaloriesGoal')
           ('DailyCaloriesLimit')
           ('DailyPhysicalActivity')
           ('WeeklyPhysicalActivity')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"DELETE FROM [dbo].[categories]
      WHERE categories.name = 'Nutrition' OR
			categories.name = 'PhysicalActivity' OR
			categories.name ='Sleep'");

            migrationBuilder.Sql(
@"INSERT INTO [dbo].[quests_types]
           ([name])
     VALUES
           ('CaloriesGoal')
           ('DailyCaloriesLimit')
           ('DailyPhysicalActivity')
           ('WeeklyPhysicalActivity')");
        }
    }
}
