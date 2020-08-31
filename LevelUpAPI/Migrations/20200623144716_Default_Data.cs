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


            migrationBuilder.Sql(
@"INSERT INTO [dbo].[advices]
	        ([category_id], [text])
        VALUES
            (1,	'Eviter de grignoter entre les repas'),
            (1, 'Buver 1 à 1.5L d''eau par jour'),
            (1,	'Eviter de manger trop gras, salé ou sucré'),
            (1,	'Manges 5 fruits et légumes par jour'),
            (1,	'Mâcher bien vos aliments pour faciliter la digestion'),
            (1,	'Ne manger pas trop vite, au moins 20 min par repas'),
            (1,	'Privilégier les produits végétaux de saison, bio et/ou d’origine locale si l’agriculteur utilise peu de pesticides.'),
            (1,	'Limiter la consommation de plats industriels, en particulier quand la liste d’ingrédients est longue.'),
            (1,	'Eviter de consommer des produits céréaliers à chaque repas.'),
            (1,	'Privilégier dans tous les cas des aliments glucidiques à index glycémique faible.'),
            (1,	'Moins l’aliment est coloré par la cuisson, mieux c’est !'),
            (1,	'Privilégier une cuisson respectueuse de l’aliment, à la vapeur douce.'),
            (1,	'Consommer chaque jour au moins 2 cuillères à soupe d’huile riche en  oméga 3.'),
            (1,	'Pas un repas sans légumes !'),
            (1,	'Saler le moins possible vos aliments.'),
            (1,	'Consommer une source significative de protéines animale ou végétale au petit-déjeuner: oeuf, fromage ou yaourt.'),
            (1,	'Limiter la consommation de charcuterie, 1 fois par semaine.'),
            (1,	'Limiter la consommation de viande hors volaille, 2 fois par semaine en privilégiant un élevage fermier.'),
            (1,	'Manger moins de viande, mais mieux !'),
            (1,	'Privilégier un déjeuner à dominante de protéines (volaille, poisson) et de légumes. '),
            (1,	'Idéalement, déshabituer du goût sucré en dessert (1 à 2 carrés de chocolat noir de qualité par exemple)'),
            (1,	'Eviter les produits light (marketing), préférer les produits légers.'),
            (1,	'Opter pour un dîner à dominante végétale à base de légumes et de légumineuses, de produits céréaliers complets ou de galettes végétales.'),
            (1,	'Maîtrisez ce que vous mangez ! Faites le ménage de printemps dans votre placard !'),
            (1,	'N''oubliez pas le plus important: Prenez du plaisir !'),
            (2,	'Pratiquer des activités physiques quotidiennes: '),
            (2,	'Effectuer des déplacements actifs quotidiens : marcher, faire du vélo, monter et utiliser les escaliers.'),
            (2,	'Effectuer des activités physiques domestiques : faire le ménage, bricoler, jardiner.'),
            (2,	'Effectuer des travaux physiques dans votre milieu professionnel.'),
            (2,	'Varier l''intensité de vos activités physiques: légère, modéré, intense'),
            (2,	'Minimiser les comportements sédentaires: se déplacer en véhicule motorisé, être assis pour travailler, regarder la télévision...'),
            (2,	'L’activité physique doit être régulière pour avoir un effet positif sur la santé.'),
            (2,	'Eviter les activités intenses par des températures extérieures < – 5 °C ou > + 30 °C et lors des pics de pollution.'),
            (2,	'Effectuer une activité physique adapté, progressive et régulière.'),
            (2,	'Du mal à commencer ? Donner un but à votre activité physique !'),
            (2,	'Du mal à commencer ? À plusieurs, c’est plus sympa !'),
            (2,	'Respecter toujours un échauffement et un récupération de 10 min.'),
            (2,	'Pendant l''exercice, buver 3 à 4 gorgés d''eau toutes les 30 mins.'),
            (2,	'Pour éviter les courbatures, hydratez vous réguliérement pendant et après l''exercice.'),
            (2,	'Pour éviter les courbatures, étirez vous après l''exercice.'),
            (3,	'En cas de somnolence durant la journée, effectuer une sieste de 5 à 20 en début d''après-midi.'),
            (3,	'Eviter les excitants après 15 heures: café, thé, sodas, vitamine C.'),
            (3,	'Pratiquer une activité physique durant la journée'),
            (3,	'Eviter de pratiquer une activité physique le soir surtout avant de vous coucher'),
            (3,	'Dîner légèrement et au moins 2 heures avant vous coucher'),
            (3,	'En fin de journée, éviter l''alcool et le tabac.'),
            (3,	'En fin de journée, effectuer des activités calmes, relaxantes.'),
            (3,	'Aménager un environnement favorable: un chambre aéré, a 18°C, isolé phoniquement, avec une obscurité totale'),
            (3,	'Gérer vos horaires de sommeil, aussi régulier que possible.'),
            (3,	'Ne vous forcez pas à dormir, suscité le sommeil par une activité calme.'),
            (3,	'Mettez vos problèmes temporairement de côté avant d’aller au lit. L’anxiété est l’une des plus grandes causes d’insomnie.'),
            (3,	'Ne comptabilisez pas votre sommeil. Accordez de l’importance à la qualité du sommeil plutôt qu’à sa quantité'),
            (3,	'Votre horloge interne aime les rythmes de sommeil réguliers. Écoutez votre corps plutôt que votre tête quand il s’agit du sommeil.')");
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

            migrationBuilder.Sql(
@"DELETE FROM [dbo].[advices]");
        }
    }
}
