using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class Skin_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__advices__categor__1A69E950",
                table: "advices");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__category__220B0B18",
                table: "quests");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__type_id__22FF2F51",
                table: "quests");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__user_id__4A18FC72",
                table: "quests");

            migrationBuilder.RenameIndex(
                name: "UQ__quests_t__72E12F1BDC557DC3",
                table: "quests_types",
                newName: "UQ__tmp_ms_x__72E12F1B414BC0C6");

            migrationBuilder.RenameIndex(
                name: "UQ__categori__72E12F1BD64C7225",
                table: "categories",
                newName: "UQ__tmp_ms_x__72E12F1BB52CA233");

            migrationBuilder.AddColumn<int>(
                name: "skin_id",
                table: "avatars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "skins",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    level_min = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skins", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avatars_skin_id",
                table: "avatars",
                column: "skin_id");

            migrationBuilder.AddForeignKey(
                name: "FK__advices__categor__6AEFE058",
                table: "advices",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_avatars_skins",
                table: "avatars",
                column: "skin_id",
                principalTable: "skins",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__category__73852659",
                table: "quests",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__type_id__74794A92",
                table: "quests",
                column: "type_id",
                principalTable: "quests_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__user_id__756D6ECB",
                table: "quests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__advices__categor__6AEFE058",
                table: "advices");

            migrationBuilder.DropForeignKey(
                name: "FK_avatars_skins",
                table: "avatars");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__category__73852659",
                table: "quests");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__type_id__74794A92",
                table: "quests");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__user_id__756D6ECB",
                table: "quests");

            migrationBuilder.DropTable(
                name: "skins");

            migrationBuilder.DropIndex(
                name: "IX_avatars_skin_id",
                table: "avatars");

            migrationBuilder.DropColumn(
                name: "skin_id",
                table: "avatars");

            migrationBuilder.RenameIndex(
                name: "UQ__tmp_ms_x__72E12F1B414BC0C6",
                table: "quests_types",
                newName: "UQ__quests_t__72E12F1BDC557DC3");

            migrationBuilder.RenameIndex(
                name: "UQ__tmp_ms_x__72E12F1BB52CA233",
                table: "categories",
                newName: "UQ__categori__72E12F1BD64C7225");

            migrationBuilder.AddForeignKey(
                name: "FK__advices__categor__1A69E950",
                table: "advices",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__category__220B0B18",
                table: "quests",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__type_id__22FF2F51",
                table: "quests",
                column: "type_id",
                principalTable: "quests_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__user_id__4A18FC72",
                table: "quests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
