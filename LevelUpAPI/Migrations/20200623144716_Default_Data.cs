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
            ('CaloriesGoal'),
            ('DailyCaloriesLimit'),
            ('DailyPhysicalActivity'),
            ('WeeklyPhysicalActivity'),
            ('DailySleepGoal')");

            migrationBuilder.Sql(
@"INSERT INTO [dbo].[physical_activities]
            ([id], [name], [cal_per_kg_per_hour])
        VALUES
            (1, 'aérobic', CAST(5.08 AS Numeric(5, 2))),
            (2, 'alpinisme', CAST(11.00 AS Numeric(5, 2))),
            (3, 'aviron', CAST(3.30 AS Numeric(5, 2))),
            (4, 'badmington', CAST(6.62 AS Numeric(5, 2))),
            (5, 'basketball (match)', CAST(9.70 AS Numeric(5, 2))),
            (6, 'bowling', CAST(2.40 AS Numeric(5, 2))),
            (7, 'boxe (entraînement)', CAST(9.00 AS Numeric(5, 2))),
            (8, 'boxe (match)', CAST(12.00 AS Numeric(5, 2))),
            (9, 'canoë (4 km/h)', CAST(3.00 AS Numeric(5, 2))),
            (10, 'canoë (6.5 km/h)', CAST(6.00 AS Numeric(5, 2))),
            (11, 'corde à sauter (modéré)', CAST(10.00 AS Numeric(5, 2))),
            (12, 'corde à sauter (intense)', CAST(12.00 AS Numeric(5, 2))),
            (13, 'course (escalier)', CAST(15.00 AS Numeric(5, 2))),
            (14, 'course (8 km/h)', CAST(8.00 AS Numeric(5, 2))),
            (15, 'course (10 km/h)', CAST(10.00 AS Numeric(5, 2))),
            (16, 'course (11 km/h)', CAST(11.00 AS Numeric(5, 2))),
            (17, 'course (12 km/h)', CAST(12.00 AS Numeric(5, 2))),
            (18, 'course (13 km/h)', CAST(13.00 AS Numeric(5, 2))),
            (19, 'course (14 km/h)', CAST(14.00 AS Numeric(5, 2))),
            (20, 'course (15 km/h)', CAST(15.00 AS Numeric(5, 2))),
            (21, 'course (16 km/h)', CAST(16.50 AS Numeric(5, 2))),
            (22, 'course (17 km/h)', CAST(18.00 AS Numeric(5, 2))),
            (23, 'cyclisme (léger)', CAST(4.00 AS Numeric(5, 2))),
            (24, 'cyclisme (modéré)', CAST(8.00 AS Numeric(5, 2))),
            (25, 'cyclisme (course)', CAST(12.00 AS Numeric(5, 2))),
            (26, 'danse (calme)', CAST(2.40 AS Numeric(5, 2))),
            (27, 'danse (intense)', CAST(6.00 AS Numeric(5, 2))),
            (28, 'escrime', CAST(6.00 AS Numeric(5, 2))),
            (29, 'football', CAST(8.60 AS Numeric(5, 2))),
            (30, 'golf', CAST(4.00 AS Numeric(5, 2))),
            (31, 'haltérophilie (léger)', CAST(4.00 AS Numeric(5, 2))),
            (32, 'haltérophilie (intense)', CAST(8.00 AS Numeric(5, 2))),
            (33, 'handball', CAST(10.00 AS Numeric(5, 2))),
            (34, 'hockey', CAST(8.00 AS Numeric(5, 2))),
            (35, 'jogging (8 km/h)', CAST(8.00 AS Numeric(5, 2))),
            (36, 'jogging (10 km/h)', CAST(10.00 AS Numeric(5, 2))),
            (37, 'judo', CAST(10.00 AS Numeric(5, 2))),
            (38, 'karate', CAST(10.00 AS Numeric(5, 2))),
            (39, 'kick boxing', CAST(10.00 AS Numeric(5, 2))),
            (40, 'lutte', CAST(6.00 AS Numeric(5, 2))),
            (41, 'marche à pied (3 km/h)', CAST(2.60 AS Numeric(5, 2))),
            (42, 'marche à pied (5 km/h)', CAST(3.50 AS Numeric(5, 2))),
            (43, 'marche à pied (6 km/h)', CAST(4.40 AS Numeric(5, 2))),
            (44, 'musculation (léger)', CAST(5.50 AS Numeric(5, 2))),
            (45, 'musculation (modéré)', CAST(8.40 AS Numeric(5, 2))),
            (46, 'musculation (intense)', CAST(11.20 AS Numeric(5, 2))),
            (47, 'natation (brasse coulée)', CAST(10.00 AS Numeric(5, 2))),
            (48, 'natation (papillon)', CAST(11.00 AS Numeric(5, 2))),
            (49, 'natation (dos crawlé)', CAST(8.00 AS Numeric(5, 2))),
            (50, 'natation (nage libre modérée)', CAST(8.00 AS Numeric(5, 2))),
            (51, 'natation (nage libre intense)', CAST(10.00 AS Numeric(5, 2))),
            (52, 'racketball', CAST(9.00 AS Numeric(5, 2))),
            (53, 'rameur', CAST(8.00 AS Numeric(5, 2))),
            (54, 'randonnée', CAST(6.80 AS Numeric(5, 2))),
            (55, 'randonnée (avec 5kg)', CAST(8.00 AS Numeric(5, 2))),
            (56, 'randonnée (avec 10kg)', CAST(8.80 AS Numeric(5, 2))),
            (57, 'randonnée (avec 15kg)', CAST(10.40 AS Numeric(5, 2))),
            (58, 'rugby', CAST(10.00 AS Numeric(5, 2))),
            (59, 'ski (descente)', CAST(6.00 AS Numeric(5, 2))),
            (60, 'ski de fond (léger)', CAST(6.80 AS Numeric(5, 2))),
            (61, 'ski de fond (modéré)', CAST(9.70 AS Numeric(5, 2))),
            (62, 'ski de fond (intense)', CAST(14.00 AS Numeric(5, 2))),
            (63, 'ski nautique', CAST(7.00 AS Numeric(5, 2))),
            (64, 'squash', CAST(9.00 AS Numeric(5, 2))),
            (65, 'stair climber (machine)', CAST(7.00 AS Numeric(5, 2))),
            (66, 'step aérobic', CAST(6.40 AS Numeric(5, 2))),
            (67, 'surf', CAST(3.00 AS Numeric(5, 2))),
            (68, 'taekwondo', CAST(10.00 AS Numeric(5, 2))),
            (69, 'tai chi', CAST(4.00 AS Numeric(5, 2))),
            (70, 'tennis (simple)', CAST(7.06 AS Numeric(5, 2))),
            (71, 'tennis (doubles)', CAST(6.00 AS Numeric(5, 2))),
            (72, 'volleyball (léger)', CAST(4.00 AS Numeric(5, 2))),
            (73, 'volleyball (match)', CAST(8.00 AS Numeric(5, 2))),
            (74, 'yoga', CAST(4.00 AS Numeric(5, 2)))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"DELETE FROM [dbo].[categories]
        WHERE 
            categories.name = 'Nutrition' OR
			categories.name = 'PhysicalActivity' OR
			categories.name = 'Sleep'");

            migrationBuilder.Sql(
@"DELETE FROM [dbo].[quests_types]
        WHERE
            quest_types.name = 'CaloriesGoal' OR
            quest_types.name = 'DailyCaloriesLimit' OR
            quest_types.name = 'DailyPhysicalActivity' OR
            quest_types.name = 'WeeklyPhysicalActivity' OR
            quest_types.name = 'DailySleepGoal'");

            migrationBuilder.Sql(
@"DELETE FROM [dbo].[physical_activities]
        WHERE
            physical_activities.id = 1 OR
            physical_activities.id = 2 OR
            physical_activities.id = 3 OR
            physical_activities.id = 4 OR
            physical_activities.id = 5 OR
            physical_activities.id = 6 OR
            physical_activities.id = 7 OR
            physical_activities.id = 8 OR
            physical_activities.id = 9 OR
            physical_activities.id = 10 OR
            physical_activities.id = 11 OR
            physical_activities.id = 12 OR
            physical_activities.id = 13 OR
            physical_activities.id = 14 OR
            physical_activities.id = 15 OR
            physical_activities.id = 16 OR
            physical_activities.id = 17 OR
            physical_activities.id = 18 OR
            physical_activities.id = 19 OR
            physical_activities.id = 20 OR
            physical_activities.id = 21 OR
            physical_activities.id = 22 OR
            physical_activities.id = 23 OR
            physical_activities.id = 24 OR
            physical_activities.id = 25 OR
            physical_activities.id = 26 OR
            physical_activities.id = 27 OR
            physical_activities.id = 28 OR
            physical_activities.id = 29 OR
            physical_activities.id = 30 OR
            physical_activities.id = 31 OR
            physical_activities.id = 32 OR
            physical_activities.id = 33 OR
            physical_activities.id = 34 OR
            physical_activities.id = 35 OR
            physical_activities.id = 36 OR
            physical_activities.id = 37 OR
            physical_activities.id = 38 OR
            physical_activities.id = 39 OR
            physical_activities.id = 40 OR
            physical_activities.id = 41 OR
            physical_activities.id = 42 OR
            physical_activities.id = 43 OR
            physical_activities.id = 44 OR
            physical_activities.id = 45 OR
            physical_activities.id = 46 OR
            physical_activities.id = 47 OR
            physical_activities.id = 48 OR
            physical_activities.id = 49 OR
            physical_activities.id = 50 OR
            physical_activities.id = 51 OR
            physical_activities.id = 52 OR
            physical_activities.id = 53 OR
            physical_activities.id = 54 OR
            physical_activities.id = 55 OR
            physical_activities.id = 56 OR
            physical_activities.id = 57 OR
            physical_activities.id = 58 OR
            physical_activities.id = 59 OR
            physical_activities.id = 60 OR
            physical_activities.id = 61 OR
            physical_activities.id = 62 OR
            physical_activities.id = 63 OR
            physical_activities.id = 64 OR
            physical_activities.id = 65 OR
            physical_activities.id = 66 OR
            physical_activities.id = 67 OR
            physical_activities.id = 68 OR
            physical_activities.id = 69 OR
            physical_activities.id = 70 OR
            physical_activities.id = 71 OR
            physical_activities.id = 72 OR
            physical_activities.id = 73 OR
            physical_activities.id = 74");
        }
    }
}
