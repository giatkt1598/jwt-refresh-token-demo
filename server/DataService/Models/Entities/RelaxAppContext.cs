using System;
using DataService.BaseConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataService.Models.Entities
{
    public partial class RelaxAppContext : BaseDbContext
    {
        public RelaxAppContext()
        {
        }

        public RelaxAppContext(DbContextOptions<RelaxAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Sound> Sounds { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedByIp)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Expired).HasColumnType("datetime");

                entity.Property(e => e.ReplaceByToken).HasMaxLength(1000);

                entity.Property(e => e.Revoked).HasColumnType("datetime");

                entity.Property(e => e.RevokedByIp).HasMaxLength(20);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_User");
            });

            modelBuilder.Entity<Sound>(entity =>
            {
                entity.ToTable("Sound");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SoundUrl)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Percy", LastName = "Vere", Password = "123", Username = "sa" }
            );

            modelBuilder.Entity<Sound>().HasData(
                new Sound { 
                    Id = 1, 
                    Title = "Epoq-Lepidoptera.ogg",
                    Author = "None", 
                    Liked = 1,
                    SoundUrl = "http://commondatastorage.googleapis.com/codeskulptor-assets/Epoq-Lepidoptera.ogg"
                },
                new Sound { 
                    Id = 2, 
                    Title = "Sevish_-__nbsp_.mp3",
                    Author = "None", 
                    Liked = 1,
                    SoundUrl = "http://commondatastorage.googleapis.com/codeskulptor-demos/DDR_assets/Sevish_-__nbsp_.mp3"
                },
                new Sound { 
                    Id = 3, 
                    Title = "theme_01.mp3",
                    Author = "None", 
                    Liked = 10,
                    SoundUrl = "http://codeskulptor-demos.commondatastorage.googleapis.com/GalaxyInvaders/theme_01.mp3"
                },
                new Sound { 
                    Id = 4, 
                    Title = "paza-moduless",
                    Author = "None", 
                    Liked = 12,
                    SoundUrl = "http://codeskulptor-demos.commondatastorage.googleapis.com/pang/paza-moduless.mp3"
                },
                new Sound { 
                    Id = 5, 
                    Title = "soundtrack.ogg",
                    Author = "None", 
                    Liked = 3,
                    SoundUrl = "http://commondatastorage.googleapis.com/codeskulptor-assets/sounddogs/soundtrack.ogg"
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
