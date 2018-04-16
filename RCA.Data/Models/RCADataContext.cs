using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RCA.Data.Models
{
    public partial class RCADataContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Cafe> Cafe { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=50.62.209.5,3306;Initial Catalog=RCA;User ID=rcaadmin;Password=Abc123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_AspNetRoleClaims_AspNetRoles_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId).IsRequired();
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("FK_AspNetUserClaims_AspNetUsers_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_AspNetUserLogins_AspNetUsers_UserId");

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_AspNetUserRoles_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnd).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasMaxLength(100);

                entity.Property(e => e.LoginProvider).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Cafe>(entity =>
            {
                entity.HasIndex(e => e.OwnerId)
                    .HasName("fk_user_cafe_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.AppKey).HasMaxLength(45);

                entity.Property(e => e.AppSecret).HasMaxLength(45);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.District).HasMaxLength(70);

                entity.Property(e => e.FacebookId)
                    .HasColumnName("FacebookID")
                    .HasMaxLength(255);

                entity.Property(e => e.LicenceEndDate).HasColumnType("datetime");

                entity.Property(e => e.LicenceStartDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.TwitterId)
                    .HasColumnName("TwitterID")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Cafe)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_user_cafe");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }
    }
}
