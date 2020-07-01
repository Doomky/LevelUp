﻿// <auto-generated />
using System;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LevelUpAPI.Migrations
{
    [DbContext(typeof(levelupContext))]
    [Migration("20200623144046_Adding_Is_Claimed")]
    partial class Adding_Is_Claimed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LevelUpAPI.Model.Advices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnName("text")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("advices");
                });

            modelBuilder.Entity("LevelUpAPI.Model.Avatars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnName("level")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnName("size")
                        .HasColumnType("int");

                    b.Property<int>("Xp")
                        .HasColumnName("xp")
                        .HasColumnType("int");

                    b.Property<int>("XpMax")
                        .HasColumnName("xp_max")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("avatars");
                });

            modelBuilder.Entity("LevelUpAPI.Model.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ__categori__72E12F1BD64C7225");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("LevelUpAPI.Model.FoodEntries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datetime")
                        .HasColumnName("datetime")
                        .HasColumnType("datetime");

                    b.Property<int>("OpenFoodFactsDataId")
                        .HasColumnName("open_food_facts_data_id")
                        .HasColumnType("int");

                    b.Property<int>("Servings")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("servings")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OpenFoodFactsDataId");

                    b.HasIndex("UserId");

                    b.ToTable("food_entries");
                });

            modelBuilder.Entity("LevelUpAPI.Model.OpenFoodFactsCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("open_food_facts_categories");
                });

            modelBuilder.Entity("LevelUpAPI.Model.OpenFoodFactsDatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<double?>("Energy100g")
                        .HasColumnName("energy_100g")
                        .HasColumnType("float");

                    b.Property<double?>("EnergyServing")
                        .HasColumnName("energy_serving")
                        .HasColumnType("float");

                    b.Property<double?>("Fat100g")
                        .HasColumnName("fat_100g")
                        .HasColumnType("float");

                    b.Property<double?>("FatServing")
                        .HasColumnName("fat_serving")
                        .HasColumnType("float");

                    b.Property<string>("ImgUrl")
                        .HasColumnName("img_url")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("IsCustom")
                        .HasColumnName("is_custom")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<double?>("Proteins100g")
                        .HasColumnName("proteins_100g")
                        .HasColumnType("float");

                    b.Property<double?>("ProteinsServing")
                        .HasColumnName("proteins_serving")
                        .HasColumnType("float");

                    b.Property<double?>("Salt100g")
                        .HasColumnName("salt_100g")
                        .HasColumnType("float");

                    b.Property<double?>("SaltServing")
                        .HasColumnName("salt_serving")
                        .HasColumnType("float");

                    b.Property<double?>("SaturatedFat100g")
                        .HasColumnName("saturated-fat_100g")
                        .HasColumnType("float");

                    b.Property<double?>("SaturatedFatServing")
                        .HasColumnName("saturated-fat_serving")
                        .HasColumnType("float");

                    b.Property<double?>("Sodium100g")
                        .HasColumnName("sodium_100g")
                        .HasColumnType("float");

                    b.Property<double?>("SodiumServing")
                        .HasColumnName("sodium_serving")
                        .HasColumnType("float");

                    b.Property<double?>("Sugars100g")
                        .HasColumnName("sugars_100g")
                        .HasColumnType("float");

                    b.Property<double?>("SugarsServing")
                        .HasColumnName("sugars_serving")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("open_food_facts_datas");
                });

            modelBuilder.Entity("LevelUpAPI.Model.OpenFoodFactsDatasCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<int>("DataId")
                        .HasColumnName("data_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DataId");

                    b.ToTable("open_food_facts_datas_categories");
                });

            modelBuilder.Entity("LevelUpAPI.Model.PasswordRecoveryDatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnName("hash")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("password_recovery_datas");
                });

            modelBuilder.Entity("LevelUpAPI.Model.PhysicalActivities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CalPerKgPerHour")
                        .HasColumnName("cal_per_kg_per_hour")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("physical_activities");
                });

            modelBuilder.Entity("LevelUpAPI.Model.PhysicalActivitiesEntries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatetimeEnd")
                        .HasColumnName("datetime_end")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DatetimeStart")
                        .HasColumnName("datetime_start")
                        .HasColumnType("datetime");

                    b.Property<int>("PhysicalActivitiesId")
                        .HasColumnName("physical_activities_id")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhysicalActivitiesId");

                    b.HasIndex("UserId");

                    b.ToTable("physical_activities_entries");
                });

            modelBuilder.Entity("LevelUpAPI.Model.Quests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("creation_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("ExpirationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("expiration_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("IsClaimed")
                        .HasColumnName("is_claimed")
                        .HasColumnType("bit");

                    b.Property<int>("ProgressCount")
                        .HasColumnName("progress_count")
                        .HasColumnType("int");

                    b.Property<int>("ProgressValue")
                        .HasColumnName("progress_value")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.Property<int?>("XpValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("xp_value")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((100))");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("quests");
                });

            modelBuilder.Entity("LevelUpAPI.Model.QuestsTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ__quests_t__72E12F1BDC557DC3");

                    b.ToTable("quests_types");
                });

            modelBuilder.Entity("LevelUpAPI.Model.SleepEntries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Datetime")
                        .HasColumnName("datetime")
                        .HasColumnType("datetime");

                    b.Property<decimal>("DurationMinutes")
                        .HasColumnName("duration_minutes")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("sleep_entries");
                });

            modelBuilder.Entity("LevelUpAPI.Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvatarId")
                        .HasColumnName("avatar_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("creation_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnName("firstname")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool?>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GoogleAccessExpiration")
                        .HasColumnName("google_access_expiration")
                        .HasColumnType("datetime");

                    b.Property<string>("GoogleAccessToken")
                        .HasColumnName("google_access_token")
                        .HasColumnType("varchar(2048)")
                        .HasMaxLength(2048)
                        .IsUnicode(false);

                    b.Property<string>("GoogleRefreshToken")
                        .HasColumnName("google_refresh_token")
                        .HasColumnType("varchar(512)")
                        .HasMaxLength(512)
                        .IsUnicode(false);

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnName("last_login_date")
                        .HasColumnType("datetime");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<byte>("WeightKg")
                        .HasColumnName("weight_kg")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("LevelUpAPI.Model.Advices", b =>
                {
                    b.HasOne("LevelUpAPI.Model.Categories", "Category")
                        .WithMany("Advices")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__advices__categor__1A69E950")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.FoodEntries", b =>
                {
                    b.HasOne("LevelUpAPI.Model.OpenFoodFactsDatas", "OpenFoodFactsData")
                        .WithMany("FoodEntries")
                        .HasForeignKey("OpenFoodFactsDataId")
                        .HasConstraintName("FK__food_entr__open___46E78A0C")
                        .IsRequired();

                    b.HasOne("LevelUpAPI.Model.Users", "User")
                        .WithMany("FoodEntries")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__food_entr__user___45F365D3")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.OpenFoodFactsDatasCategories", b =>
                {
                    b.HasOne("LevelUpAPI.Model.OpenFoodFactsCategories", "Category")
                        .WithMany("OpenFoodFactsDatasCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_open_food_facts_categories_ToTable")
                        .IsRequired();

                    b.HasOne("LevelUpAPI.Model.OpenFoodFactsDatas", "Data")
                        .WithMany("OpenFoodFactsDatasCategories")
                        .HasForeignKey("DataId")
                        .HasConstraintName("FK_open_food_facts_categories_ToTable_1")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.PasswordRecoveryDatas", b =>
                {
                    b.HasOne("LevelUpAPI.Model.Users", "User")
                        .WithMany("PasswordRecoveryDatas")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_password_recovery_user_id_key")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.PhysicalActivitiesEntries", b =>
                {
                    b.HasOne("LevelUpAPI.Model.PhysicalActivities", "PhysicalActivities")
                        .WithMany("PhysicalActivitiesEntries")
                        .HasForeignKey("PhysicalActivitiesId")
                        .HasConstraintName("FK__physical___physi__4CA06362")
                        .IsRequired();

                    b.HasOne("LevelUpAPI.Model.Users", "User")
                        .WithMany("PhysicalActivitiesEntries")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__physical___user___4BAC3F29")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.Quests", b =>
                {
                    b.HasOne("LevelUpAPI.Model.Categories", "Category")
                        .WithMany("Quests")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__quests__category__220B0B18")
                        .IsRequired();

                    b.HasOne("LevelUpAPI.Model.QuestsTypes", "Type")
                        .WithMany("Quests")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK__quests__type_id__22FF2F51")
                        .IsRequired();

                    b.HasOne("LevelUpAPI.Model.Users", "User")
                        .WithMany("Quests")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__quests__user_id__4A18FC72")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.SleepEntries", b =>
                {
                    b.HasOne("LevelUpAPI.Model.Users", "User")
                        .WithMany("SleepEntries")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__sleep_ent__user___4F7CD00D")
                        .IsRequired();
                });

            modelBuilder.Entity("LevelUpAPI.Model.Users", b =>
                {
                    b.HasOne("LevelUpAPI.Model.Avatars", "Avatar")
                        .WithMany("Users")
                        .HasForeignKey("AvatarId")
                        .HasConstraintName("FK__users__avatar_id__398D8EEE")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
