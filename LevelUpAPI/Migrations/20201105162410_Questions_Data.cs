using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class Questions_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"INSERT INTO [dbo].[questions]
            ([text], [response_a], [response_b], [response_c], [response_d], [correct_answer])
        VALUES
            ('Quels sont les besoins en calories journaliers pour un homme ?', '1900', '2000', '2100', '2200', 'C'),
            ('Quels sont les besoins en calories journaliers pour une femme ?', '1800', '1900', '2000', '2100', 'A'),
            ('Quelle est l''espérance de vie en France en 2017 ?', '62', '72', '82', '92', 'C'),
            ('Quel est l''IMC recommandé ?', '13,5 - 18,5', '18,5 - 25', '25 - 28,5', '28,5 - 35', 'B'),
            ('Où se trouvent les glandes sudoripares d''un chien ?', 'Sous ses pattes', 'Sous sa langue', 'Entre ses deux pattes arrière', 'Dans son cou', 'A'),
            ('Qui fut le quarantième président des USA  ?', 'Nixon', 'Bush', ' Reagan', ' Clinton', 'B'),
            ('Le score maximum pour une partie de bowling est ?', '100', '200', ' 250', ' 300', 'D'),
            ('1 + 2 + 3 + 4 + 5 ?', '9', '12', ' 15', ' 18', 'C'),
            ('De quelle couleur sont les jonquilles ?', 'Jaune', 'Rouge', ' Bleu', 'Vert', 'A'),
            ('A partir de quel taux d''alcool est-il interdit de prendre le volant ?', '0,5 g/l', '0,6 g/l', '0,7 g/l', '0,8 g/l', 'A'),
            ('Combien de pattes peut avoir au maximum le mille-pattes?', '500', '750', '1000', '1250', 'B'),
            ('Quel est le nombre de millions d''habitants en France ?', '64', '65', '66', '67', 'D')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"DELETE FROM [dbo].[questions]");
        }
    }
}
