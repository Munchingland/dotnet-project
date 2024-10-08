﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pri.GameLibrary.Infrastructure.Data;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231110142701_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("GamePlatform");

                    b.HasData(
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 4
                        },
                        new
                        {
                            GamesId = 2,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 2,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 3,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 3,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 3,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 3,
                            PlatformsId = 4
                        },
                        new
                        {
                            GamesId = 4,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 5,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 6,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 7,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 8,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 9,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 10,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 10,
                            PlatformsId = 4
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "49c94ebb-2b17-4e6b-861d-e8854dc22a1f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "e6c8c437-73c6-4bd7-a266-30a4747fdb8c",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "3",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "1",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1986, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bethesda"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Double Fine"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(1986, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "FromSoftware"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(1989, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game Freak"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Santa Monica Studios"
                        });
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 2,
                            Name = "Psychonauts 2"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 5,
                            Name = "God of War"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2018, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 3,
                            Name = "Dark Souls: Remastered"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 3,
                            Name = "Elden Ring"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 3,
                            Name = "Bloodborne"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 4,
                            Name = "Pokemon Scarlet"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 4,
                            Name = "Pokemon Violet"
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 4,
                            Name = "Pokemon Sword"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 4,
                            Name = "Pokemon Shield"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeveloperId = 1,
                            Name = "Starfield"
                        });
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.GameUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.HasIndex("ReviewId");

                    b.ToTable("GamesUsers");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            GameId = 1,
                            ReviewId = 1
                        },
                        new
                        {
                            UserId = "1",
                            GameId = 7,
                            ReviewId = 2
                        },
                        new
                        {
                            UserId = "1",
                            GameId = 10,
                            ReviewId = 3
                        },
                        new
                        {
                            UserId = "1",
                            GameId = 4,
                            ReviewId = 4
                        },
                        new
                        {
                            UserId = "3",
                            GameId = 9
                        },
                        new
                        {
                            UserId = "1",
                            GameId = 5,
                            ReviewId = 5
                        });
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2003, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Steam"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2013, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Playstation 4"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nintendo Switch"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2013, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Xbox One S"
                        });
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8704),
                            Description = "Psychonauts 2 is everything I wanted a Psychonauts sequel to be. It delivers on a compelling new chapter of the story full of unique characters, tighter platforming, amazing combat for a platformer, and best of all: incredible new mind-themed worlds to explore. Unlike the original, Psychonauts 2 doesn’t suffer from inconsistent difficulty and flubbing level gimmicks. The worst I can say is that the pacing at the very end felt a little off and occasionally voice lines got interrupted, but if you’re a fan of collectathon platformers, or 3D platformers in general, I cannot recommend Psychonauts 2 enough.",
                            Rating = 9
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8708),
                            Rating = 3
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8710),
                            Rating = 8
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8712),
                            Rating = 7
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8713),
                            Rating = 6
                        });
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasApprovedTermsAndConditions")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "dfad7ab2-1654-4d59-b0b2-44bfd12b8f69",
                            Email = "admin@pri.be",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@PRI.BE",
                            NormalizedUserName = "PRIADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJuwhPaDmWajyqjlFvk6DK6+dGqJxGa3bmFpxvLiQCaMb9C8Is/EiIqcYINlx7+Xxw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8b7549bf-006e-462b-bead-39ffab16daba",
                            TwoFactorEnabled = false,
                            UserName = "PriAdmin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "004443f1-9d88-4824-88d1-465a9ca92b8c",
                            Email = "refuser@pri.be",
                            EmailConfirmed = false,
                            HasApprovedTermsAndConditions = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "REFUSER@PRI.BE",
                            NormalizedUserName = "PRIREFUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEPF6hYejeC+5vusO+LS7aGv51xa1K8k1LJ9JGPxpbBWxHcybG/xIW+XoO8i6G9awsw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "24cbd802-c1b1-4e7f-8a5c-b19eec90797c",
                            TwoFactorEnabled = false,
                            UserName = "PriRefuser"
                        },
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2023, 11, 10, 15, 27, 1, 12, DateTimeKind.Local).AddTicks(830),
                            ConcurrencyStamp = "44e513c7-a99f-4dd0-bf03-e28c58f0e011",
                            Email = "user@pri.be",
                            EmailConfirmed = false,
                            HasApprovedTermsAndConditions = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@PRI.BE",
                            NormalizedUserName = "PRIUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEL91kYNuCnIXF5IrlhyBTFMPZL+gFAH0hjEyIYpyLkujBzczuLGAP/Ce6TLzF4M/ww==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7d6ca299-9a98-47e1-89cb-59af1182ac7c",
                            TwoFactorEnabled = false,
                            UserName = "PriUser"
                        });
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("Pri.GameLibrary.Core.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pri.GameLibrary.Core.Entities.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Pri.GameLibrary.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pri.GameLibrary.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pri.GameLibrary.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pri.GameLibrary.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Game", b =>
                {
                    b.HasOne("Pri.GameLibrary.Core.Entities.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.GameUser", b =>
                {
                    b.HasOne("Pri.GameLibrary.Core.Entities.Game", "Game")
                        .WithMany("Users")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pri.GameLibrary.Core.Entities.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.HasOne("Pri.GameLibrary.Core.Entities.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Developer", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.Game", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Pri.GameLibrary.Core.Entities.User", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
