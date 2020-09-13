using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LevelUpAPI.Model
{
    public partial class levelupContext : DbContext
    {
        public levelupContext()
        {
        }

        public levelupContext(DbContextOptions<levelupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advices> Advices { get; set; }
        public virtual DbSet<Avatars> Avatars { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<FoodEntries> FoodEntries { get; set; }
        public virtual DbSet<NbFoodEntriesByLogin> NbFoodEntriesByLogin { get; set; }
        public virtual DbSet<NbPhysicalActivitiesEntriesByLogin> NbPhysicalActivitiesEntriesByLogin { get; set; }
        public virtual DbSet<OpenFoodFactsCategories> OpenFoodFactsCategories { get; set; }
        public virtual DbSet<OpenFoodFactsDatas> OpenFoodFactsDatas { get; set; }
        public virtual DbSet<OpenFoodFactsDatasCategories> OpenFoodFactsDatasCategories { get; set; }
        public virtual DbSet<PasswordRecoveryDatas> PasswordRecoveryDatas { get; set; }
        public virtual DbSet<PhysicalActivities> PhysicalActivities { get; set; }
        public virtual DbSet<PhysicalActivitiesEntries> PhysicalActivitiesEntries { get; set; }
        public virtual DbSet<PhysicalActivitiesEntriesByLogin> PhysicalActivitiesEntriesByLogin { get; set; }
        public virtual DbSet<Quests> Quests { get; set; }
        public virtual DbSet<QuestsTypes> QuestsTypes { get; set; }
        public virtual DbSet<Skins> Skins { get; set; }
        public virtual DbSet<SleepEntries> SleepEntries { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advices>(entity =>
            {
                entity.ToTable("advices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Advices)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__advices__categor__6AEFE058");
            });

            modelBuilder.Entity<Avatars>(entity =>
            {
                entity.ToTable("avatars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.SkinId).HasColumnName("skin_id");

                entity.Property(e => e.Xp).HasColumnName("xp");

                entity.Property(e => e.XpMax).HasColumnName("xp_max");

                entity.HasOne(d => d.Skin)
                    .WithMany(p => p.Avatars)
                    .HasForeignKey(d => d.SkinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_avatars_skins");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__tmp_ms_x__72E12F1BB52CA233")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FoodEntries>(entity =>
            {
                entity.ToTable("food_entries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpenFoodFactsDataId).HasColumnName("open_food_facts_data_id");

                entity.Property(e => e.Servings)
                    .HasColumnName("servings")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.OpenFoodFactsData)
                    .WithMany(p => p.FoodEntries)
                    .HasForeignKey(d => d.OpenFoodFactsDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__food_entr__open___46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FoodEntries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__food_entr__user___45F365D3");
            });

            modelBuilder.Entity<NbFoodEntriesByLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("nb_food_entries_by_login");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<NbPhysicalActivitiesEntriesByLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("nb_physical_activities_entries_by_login");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<OpenFoodFactsCategories>(entity =>
            {
                entity.ToTable("open_food_facts_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpenFoodFactsDatas>(entity =>
            {
                entity.ToTable("open_food_facts_datas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Energy100g).HasColumnName("energy_100g");

                entity.Property(e => e.EnergyServing).HasColumnName("energy_serving");

                entity.Property(e => e.Fat100g).HasColumnName("fat_100g");

                entity.Property(e => e.FatServing).HasColumnName("fat_serving");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("img_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsCustom).HasColumnName("is_custom");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Proteins100g).HasColumnName("proteins_100g");

                entity.Property(e => e.ProteinsServing).HasColumnName("proteins_serving");

                entity.Property(e => e.Salt100g).HasColumnName("salt_100g");

                entity.Property(e => e.SaltServing).HasColumnName("salt_serving");

                entity.Property(e => e.SaturatedFat100g).HasColumnName("saturated-fat_100g");

                entity.Property(e => e.SaturatedFatServing).HasColumnName("saturated-fat_serving");

                entity.Property(e => e.Sodium100g).HasColumnName("sodium_100g");

                entity.Property(e => e.SodiumServing).HasColumnName("sodium_serving");

                entity.Property(e => e.Sugars100g).HasColumnName("sugars_100g");

                entity.Property(e => e.SugarsServing).HasColumnName("sugars_serving");
            });

            modelBuilder.Entity<OpenFoodFactsDatasCategories>(entity =>
            {
                entity.ToTable("open_food_facts_datas_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.OpenFoodFactsDatasCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_open_food_facts_categories_ToTable");

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.OpenFoodFactsDatasCategories)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_open_food_facts_categories_ToTable_1");
            });

            modelBuilder.Entity<PasswordRecoveryDatas>(entity =>
            {
                entity.ToTable("password_recovery_datas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PasswordRecoveryDatas)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_password_recovery_user_id_key");
            });

            modelBuilder.Entity<PhysicalActivities>(entity =>
            {
                entity.ToTable("physical_activities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CalPerKgPerHour)
                    .HasColumnName("cal_per_kg_per_hour")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhysicalActivitiesEntries>(entity =>
            {
                entity.ToTable("physical_activities_entries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatetimeEnd)
                    .HasColumnName("datetime_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatetimeStart)
                    .HasColumnName("datetime_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhysicalActivitiesId).HasColumnName("physical_activities_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.PhysicalActivities)
                    .WithMany(p => p.PhysicalActivitiesEntries)
                    .HasForeignKey(d => d.PhysicalActivitiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__physical___physi__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PhysicalActivitiesEntries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__physical___user___4BAC3F29");
            });

            modelBuilder.Entity<PhysicalActivitiesEntriesByLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("physical_activities_entries_by_login");

                entity.Property(e => e.CalPerKgPerHour)
                    .HasColumnName("cal_per_kg_per_hour")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.DatetimeEnd)
                    .HasColumnName("datetime_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatetimeStart)
                    .HasColumnName("datetime_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quests>(entity =>
            {
                entity.ToTable("quests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsClaimed).HasColumnName("is_claimed");

                entity.Property(e => e.ProgressCount).HasColumnName("progress_count");

                entity.Property(e => e.ProgressValue).HasColumnName("progress_value");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.XpValue)
                    .HasColumnName("xp_value")
                    .HasDefaultValueSql("((100))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quests__category__73852659");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quests__type_id__74794A92");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quests__user_id__756D6ECB");
            });

            modelBuilder.Entity<QuestsTypes>(entity =>
            {
                entity.ToTable("quests_types");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__tmp_ms_x__72E12F1B414BC0C6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skins>(entity =>
            {
                entity.ToTable("skins");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LevelMin).HasColumnName("level_min");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SleepEntries>(entity =>
            {
                entity.ToTable("sleep_entries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DurationMinutes)
                    .HasColumnName("duration_minutes")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SleepEntries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sleep_ent__user___4F7CD00D");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvatarId).HasColumnName("avatar_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.GoogleAccessExpiration)
                    .HasColumnName("google_access_expiration")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoogleAccessToken)
                    .HasColumnName("google_access_token")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleRefreshToken)
                    .HasColumnName("google_refresh_token")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginDate)
                    .HasColumnName("last_login_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WeightKg).HasColumnName("weight_kg");

                entity.HasOne(d => d.Avatar)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AvatarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__avatar_id__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
