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
        public virtual DbSet<PhysicalActivites> PhysicalActivites { get; set; }
        public virtual DbSet<PhysicalActivitesEntries> PhysicalActivitesEntries { get; set; }
        public virtual DbSet<Quests> Quests { get; set; }
        public virtual DbSet<QuestsTypes> QuestsTypes { get; set; }
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
                    .HasConstraintName("FK__advices__categor__151B244E");
            });

            modelBuilder.Entity<Avatars>(entity =>
            {
                entity.ToTable("avatars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Xp).HasColumnName("xp");

                entity.Property(e => e.XpMax).HasColumnName("xp_max");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
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

                entity.ToView("NbFoodEntriesByLogin");

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

                entity.ToView("NbPhysicalActivitiesEntriesByLogin");

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
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<OpenFoodFactsDatas>(entity =>
            {
                entity.ToTable("open_food_facts_datas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Energy100g).HasColumnName("energy_100g");

                entity.Property(e => e.EnergyServing).HasColumnName("energy_serving");

                entity.Property(e => e.Fat100g).HasColumnName("fat_100g");

                entity.Property(e => e.FatServing).HasColumnName("fat_serving");

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

            modelBuilder.Entity<PhysicalActivites>(entity =>
            {
                entity.ToTable("physical_activites");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KcalPerHour)
                    .HasColumnName("kcal_per_hour")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhysicalActivitesEntries>(entity =>
            {
                entity.ToTable("physical_activites_entries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhysicalActivitesId).HasColumnName("physical_activites_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.PhysicalActivites)
                    .WithMany(p => p.PhysicalActivitesEntries)
                    .HasForeignKey(d => d.PhysicalActivitesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__physical___physi__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PhysicalActivitesEntries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__physical___user___4BAC3F29");
            });

            modelBuilder.Entity<Quests>(entity =>
            {
                entity.ToTable("quests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProgressCount).HasColumnName("progress_count");

                entity.Property(e => e.ProgressValue).HasColumnName("progress_value");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quests__category__04E4BC85");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quests__type_id__05D8E0BE");
            });

            modelBuilder.Entity<QuestsTypes>(entity =>
            {
                entity.ToTable("quests_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255)
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

                entity.Property(e => e.GoogleId)
                    .HasColumnName("google_id")
                    .HasMaxLength(255)
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
