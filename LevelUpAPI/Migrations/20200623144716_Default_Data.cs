﻿using LevelUpAPI.Model;
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
            ([name], [cal_per_kg_per_hour])
        VALUES
            ('aérobic', CAST(5.08 AS Numeric(5, 2))),
            ('alpinisme', CAST(11.00 AS Numeric(5, 2))),
            ('aviron', CAST(3.30 AS Numeric(5, 2))),
            ('badmington', CAST(6.62 AS Numeric(5, 2))),
            ('basketball (match)', CAST(9.70 AS Numeric(5, 2))),
            ('bowling', CAST(2.40 AS Numeric(5, 2))),
            ('boxe (entraînement)', CAST(9.00 AS Numeric(5, 2))),
            ('boxe (match)', CAST(12.00 AS Numeric(5, 2))),
            ('canoë (4 km/h)', CAST(3.00 AS Numeric(5, 2))),
            ('canoë (6.5 km/h)', CAST(6.00 AS Numeric(5, 2))),
            ('corde à sauter (modéré)', CAST(10.00 AS Numeric(5, 2))),
            ('corde à sauter (intense)', CAST(12.00 AS Numeric(5, 2))),
            ('course (escalier)', CAST(15.00 AS Numeric(5, 2))),
            ('course (8 km/h)', CAST(8.00 AS Numeric(5, 2))),
            ('course (10 km/h)', CAST(10.00 AS Numeric(5, 2))),
            ('course (11 km/h)', CAST(11.00 AS Numeric(5, 2))),
            ('course (12 km/h)', CAST(12.00 AS Numeric(5, 2))),
            ('course (13 km/h)', CAST(13.00 AS Numeric(5, 2))),
            ('course (14 km/h)', CAST(14.00 AS Numeric(5, 2))),
            ('course (15 km/h)', CAST(15.00 AS Numeric(5, 2))),
            ('course (16 km/h)', CAST(16.50 AS Numeric(5, 2))),
            ('course (17 km/h)', CAST(18.00 AS Numeric(5, 2))),
            ('cyclisme (léger)', CAST(4.00 AS Numeric(5, 2))),
            ('cyclisme (modéré)', CAST(8.00 AS Numeric(5, 2))),
            ('cyclisme (course)', CAST(12.00 AS Numeric(5, 2))),
            ('danse (calme)', CAST(2.40 AS Numeric(5, 2))),
            ('danse (intense)', CAST(6.00 AS Numeric(5, 2))),
            ('escrime', CAST(6.00 AS Numeric(5, 2))),
            ('football', CAST(8.60 AS Numeric(5, 2))),
            ('golf', CAST(4.00 AS Numeric(5, 2))),
            ('haltérophilie (léger)', CAST(4.00 AS Numeric(5, 2))),
            ('haltérophilie (intense)', CAST(8.00 AS Numeric(5, 2))),
            ('handball', CAST(10.00 AS Numeric(5, 2))),
            ('hockey', CAST(8.00 AS Numeric(5, 2))),
            ('jogging (8 km/h)', CAST(8.00 AS Numeric(5, 2))),
            ('jogging (10 km/h)', CAST(10.00 AS Numeric(5, 2))),
            ('judo', CAST(10.00 AS Numeric(5, 2))),
            ('karate', CAST(10.00 AS Numeric(5, 2))),
            ('kick boxing', CAST(10.00 AS Numeric(5, 2))),
            ('lutte', CAST(6.00 AS Numeric(5, 2))),
            ('marche à pied (3 km/h)', CAST(2.60 AS Numeric(5, 2))),
            ('marche à pied (5 km/h)', CAST(3.50 AS Numeric(5, 2))),
            ('marche à pied (6 km/h)', CAST(4.40 AS Numeric(5, 2))),
            ('musculation (léger)', CAST(5.50 AS Numeric(5, 2))),
            ('musculation (modéré)', CAST(8.40 AS Numeric(5, 2))),
            ('musculation (intense)', CAST(11.20 AS Numeric(5, 2))),
            ('natation (brasse coulée)', CAST(10.00 AS Numeric(5, 2))),
            ('natation (papillon)', CAST(11.00 AS Numeric(5, 2))),
            ('natation (dos crawlé)', CAST(8.00 AS Numeric(5, 2))),
            ('natation (nage libre modérée)', CAST(8.00 AS Numeric(5, 2))),
            ('natation (nage libre intense)', CAST(10.00 AS Numeric(5, 2))),
            ('racketball', CAST(9.00 AS Numeric(5, 2))),
            ('rameur', CAST(8.00 AS Numeric(5, 2))),
            ('randonnée', CAST(6.80 AS Numeric(5, 2))),
            ('randonnée (avec 5kg)', CAST(8.00 AS Numeric(5, 2))),
            ('randonnée (avec 10kg)', CAST(8.80 AS Numeric(5, 2))),
            ('randonnée (avec 15kg)', CAST(10.40 AS Numeric(5, 2))),
            ('rugby', CAST(10.00 AS Numeric(5, 2))),
            ('ski (descente)', CAST(6.00 AS Numeric(5, 2))),
            ('ski de fond (léger)', CAST(6.80 AS Numeric(5, 2))),
            ('ski de fond (modéré)', CAST(9.70 AS Numeric(5, 2))),
            ('ski de fond (intense)', CAST(14.00 AS Numeric(5, 2))),
            ('ski nautique', CAST(7.00 AS Numeric(5, 2))),
            ('squash', CAST(9.00 AS Numeric(5, 2))),
            ('stair climber (machine)', CAST(7.00 AS Numeric(5, 2))),
            ('step aérobic', CAST(6.40 AS Numeric(5, 2))),
            ('surf', CAST(3.00 AS Numeric(5, 2))),
            ('taekwondo', CAST(10.00 AS Numeric(5, 2))),
            ('tai chi', CAST(4.00 AS Numeric(5, 2))),
            ('tennis (simple)', CAST(7.06 AS Numeric(5, 2))),
            ('tennis (doubles)', CAST(6.00 AS Numeric(5, 2))),
            ('volleyball (léger)', CAST(4.00 AS Numeric(5, 2))),
            ('volleyball (match)', CAST(8.00 AS Numeric(5, 2))),
            ('yoga', CAST(4.00 AS Numeric(5, 2)))");
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
