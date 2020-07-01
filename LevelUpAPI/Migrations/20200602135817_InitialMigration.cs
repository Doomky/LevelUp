using System;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelUpAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "avatars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level = table.Column<int>(nullable: false),
                    xp = table.Column<int>(nullable: false),
                    xp_max = table.Column<int>(nullable: false),
                    size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avatars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "open_food_facts_categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_open_food_facts_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "open_food_facts_datas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    energy_100g = table.Column<double>(nullable: true),
                    sodium_100g = table.Column<double>(nullable: true),
                    salt_100g = table.Column<double>(nullable: true),
                    fat_100g = table.Column<double>(nullable: true),
                    saturatedfat_100g = table.Column<double>(name: "saturated-fat_100g", nullable: true),
                    proteins_100g = table.Column<double>(nullable: true),
                    sugars_100g = table.Column<double>(nullable: true),
                    energy_serving = table.Column<double>(nullable: true),
                    sodium_serving = table.Column<double>(nullable: true),
                    salt_serving = table.Column<double>(nullable: true),
                    fat_serving = table.Column<double>(nullable: true),
                    saturatedfat_serving = table.Column<double>(name: "saturated-fat_serving", nullable: true),
                    proteins_serving = table.Column<double>(nullable: true),
                    sugars_serving = table.Column<double>(nullable: true),
                    img_url = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    is_custom = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_open_food_facts_datas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "physical_activities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    cal_per_kg_per_hour = table.Column<decimal>(type: "numeric(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_activities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quests_types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quests_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    firstname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    lastname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    gender = table.Column<bool>(nullable: true),
                    weight_kg = table.Column<byte>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    last_login_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    password_hash = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    avatar_id = table.Column<int>(nullable: false),
                    google_access_token = table.Column<string>(unicode: false, maxLength: 2048, nullable: true),
                    google_refresh_token = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    google_access_expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK__users__avatar_id__398D8EEE",
                        column: x => x.avatar_id,
                        principalTable: "avatars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "advices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    text = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advices", x => x.id);
                    table.ForeignKey(
                        name: "FK__advices__categor__4AB81AF0",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "open_food_facts_datas_categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    data_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_open_food_facts_datas_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_open_food_facts_categories_ToTable",
                        column: x => x.category_id,
                        principalTable: "open_food_facts_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_open_food_facts_categories_ToTable_1",
                        column: x => x.data_id,
                        principalTable: "open_food_facts_datas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "food_entries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    open_food_facts_data_id = table.Column<int>(nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    servings = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_entries", x => x.id);
                    table.ForeignKey(
                        name: "FK__food_entr__open___46E78A0C",
                        column: x => x.open_food_facts_data_id,
                        principalTable: "open_food_facts_datas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__food_entr__user___45F365D3",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "password_recovery_datas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    hash = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_recovery_datas", x => x.id);
                    table.ForeignKey(
                        name: "FK_password_recovery_user_id_key",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "physical_activities_entries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    physical_activities_id = table.Column<int>(nullable: false),
                    datetime_start = table.Column<DateTime>(type: "datetime", nullable: false),
                    datetime_end = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_activities_entries", x => x.id);
                    table.ForeignKey(
                        name: "FK__physical___physi__4CA06362",
                        column: x => x.physical_activities_id,
                        principalTable: "physical_activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__physical___user___4BAC3F29",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    type_id = table.Column<int>(nullable: false),
                    progress_value = table.Column<int>(nullable: false),
                    progress_count = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    xp_value = table.Column<int>(nullable: true, defaultValueSql: "((100))"),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    expiration_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quests", x => x.id);
                    table.ForeignKey(
                        name: "FK__quests__category__4F7CD00D",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quests__type_id__5070F446",
                        column: x => x.type_id,
                        principalTable: "quests_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quests__user_id__30C33EC3",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sleep_entries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    duration_minutes = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sleep_entries", x => x.id);
                    table.ForeignKey(
                        name: "FK__sleep_ent__user___4F7CD00D",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advices_category_id",
                table: "advices",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__categori__72E12F1B0B21EAEC",
                table: "categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_food_entries_open_food_facts_data_id",
                table: "food_entries",
                column: "open_food_facts_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_food_entries_user_id",
                table: "food_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_open_food_facts_datas_categories_category_id",
                table: "open_food_facts_datas_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_open_food_facts_datas_categories_data_id",
                table: "open_food_facts_datas_categories",
                column: "data_id");

            migrationBuilder.CreateIndex(
                name: "IX_password_recovery_datas_user_id",
                table: "password_recovery_datas",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_activities_entries_physical_activities_id",
                table: "physical_activities_entries",
                column: "physical_activities_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_activities_entries_user_id",
                table: "physical_activities_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quests_category_id",
                table: "quests",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_quests_type_id",
                table: "quests",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_quests_user_id",
                table: "quests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__quests_t__72E12F1B5610411D",
                table: "quests_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sleep_entries_user_id",
                table: "sleep_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_avatar_id",
                table: "users",
                column: "avatar_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advices");

            migrationBuilder.DropTable(
                name: "food_entries");

            migrationBuilder.DropTable(
                name: "open_food_facts_datas_categories");

            migrationBuilder.DropTable(
                name: "password_recovery_datas");

            migrationBuilder.DropTable(
                name: "physical_activities_entries");

            migrationBuilder.DropTable(
                name: "quests");

            migrationBuilder.DropTable(
                name: "sleep_entries");

            migrationBuilder.DropTable(
                name: "open_food_facts_categories");

            migrationBuilder.DropTable(
                name: "open_food_facts_datas");

            migrationBuilder.DropTable(
                name: "physical_activities");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "quests_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "avatars");
        }
    }
}
