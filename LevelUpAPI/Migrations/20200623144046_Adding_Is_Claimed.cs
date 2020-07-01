using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class Adding_Is_Claimed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__advices__categor__4AB81AF0",
                table: "advices");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__category__4F7CD00D",
                table: "quests");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__type_id__5070F446",
                table: "quests");

            migrationBuilder.DropForeignKey(
                name: "FK__quests__user_id__30C33EC3",
                table: "quests");

            migrationBuilder.RenameIndex(
                name: "UQ__quests_t__72E12F1B5610411D",
                table: "quests_types",
                newName: "UQ__quests_t__72E12F1BDC557DC3");

            migrationBuilder.RenameIndex(
                name: "UQ__categori__72E12F1B0B21EAEC",
                table: "categories",
                newName: "UQ__categori__72E12F1BD64C7225");

            migrationBuilder.AddColumn<bool>(
                name: "is_claimed",
                table: "quests",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "is_claimed",
                table: "quests");

            migrationBuilder.RenameIndex(
                name: "UQ__quests_t__72E12F1BDC557DC3",
                table: "quests_types",
                newName: "UQ__quests_t__72E12F1B5610411D");

            migrationBuilder.RenameIndex(
                name: "UQ__categori__72E12F1BD64C7225",
                table: "categories",
                newName: "UQ__categori__72E12F1B0B21EAEC");

            migrationBuilder.AddForeignKey(
                name: "FK__advices__categor__4AB81AF0",
                table: "advices",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__category__4F7CD00D",
                table: "quests",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__type_id__5070F446",
                table: "quests",
                column: "type_id",
                principalTable: "quests_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__quests__user_id__30C33EC3",
                table: "quests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
