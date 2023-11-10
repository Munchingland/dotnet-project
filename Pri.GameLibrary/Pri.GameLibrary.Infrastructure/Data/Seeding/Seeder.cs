using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pri.GameLibrary.Core.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Pri.GameLibrary.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Created = new DateTime(2003,09,12),
                    Name = "Steam",
                    Id = 1
                },
                new Platform
                {
                    Created = new DateTime(2013,11,15),
                    Name = "Playstation 4",
                    Id = 2
                },
                new Platform
                {
                    Created = new DateTime(2017,03,3),
                    Name = "Nintendo Switch",
                    Id = 3
                },
                new Platform
                {
                    Created = new DateTime(2013, 08, 02),
                    Name = "Xbox One S",
                    Id = 4
                });
            
            modelBuilder.Entity<Developer>().HasData(
                new Developer
                {
                    Created = new DateTime(1986, 06, 28),
                    Name = "Bethesda",
                    Id = 1
                },
                new Developer
                {
                    Created = new DateTime(2000,07, 1),
                    Name = "Double Fine",
                    Id= 2
                },
                new Developer
                {
                    Created = new DateTime(1986, 11, 1),
                    Name = "FromSoftware",
                    Id = 3
                },
                new Developer
                {
                    Created = new DateTime(1989,04,26),
                    Name = "Game Freak",
                    Id = 4
                },
                new Developer
                {
                    Created = new DateTime(1999,1,1),
                    Name = "Santa Monica Studios",
                    Id= 5
                });

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Created = new DateTime(2021, 08, 25),
                    Id = 1,
                    Name = "Psychonauts 2",
                    DeveloperId = 2,
                },
                new Game
                {
                    Created = new DateTime(2018,04,20),
                    Id = 2,
                    Name = "God of War",
                    DeveloperId = 5
                },
                new Game
                {
                    Created = new DateTime(2018, 05, 23),
                    Id = 3,
                    Name = "Dark Souls: Remastered",
                    DeveloperId = 3
                },
                new Game
                {
                    Created = new DateTime(2022, 02, 25),
                    Id = 4,
                    Name = "Elden Ring",
                    DeveloperId = 3
                },
                new Game
                {
                    Created = new DateTime(2015, 03, 24),
                    Id = 5,
                    Name = "Bloodborne",
                    DeveloperId = 3
                },
                new Game
                {
                    Created = new DateTime(2022, 11, 18),
                    Id=6,
                    Name= "Pokemon Scarlet",
                    DeveloperId = 4
                },
                new Game
                {
                    Created = new DateTime(2022, 11, 18),
                    Id = 7,
                    Name = "Pokemon Violet",
                    DeveloperId = 4
                },
                new Game
                {
                    Created = new DateTime(2019, 11, 15),
                    Id = 8,
                    Name = "Pokemon Sword",
                    DeveloperId = 4
                },
                new Game
                {
                    Created = new DateTime(2019, 11, 15),
                    Id = 9,
                    Name = "Pokemon Shield",
                    DeveloperId = 4
                },
                new Game
                {
                    Created = new DateTime(2023, 09, 6),
                    Id = 10,
                    Name = "Starfield",
                    DeveloperId = 1
                });
            IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var user = new User
            {
                BirthDay = DateTime.Now,
                Id = "1",
                UserName = "PriUser",
                NormalizedUserName = "PRIUSER",
                Email = "user@pri.be",
                NormalizedEmail = "USER@PRI.BE",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                HasApprovedTermsAndConditions = true,
            };
            var refuser = new User
            {
                BirthDay = DateTime.Parse("2016-05-02"),
                Id = "2",
                UserName = "PriRefuser",
                NormalizedUserName ="PRIREFUSER",
                Email = "refuser@pri.be",
                NormalizedEmail = "REFUSER@PRI.BE",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                HasApprovedTermsAndConditions = false
            };
            var admin = new User
            {
                BirthDay = DateTime.Parse("2016-05-02"),
                Id = "3",
                UserName = "PriAdmin",
                NormalizedUserName = "PRIADMIN",
                Email = "admin@pri.be",
                NormalizedEmail = "ADMIN@PRI.BE",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Test123?");
            refuser.PasswordHash = passwordHasher.HashPassword(refuser, "Test123?");
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123?");
            modelBuilder.Entity<User>().HasData(new User[] {admin, refuser, user});

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Created = DateTime.Now,
                    Id = 1,
                    Rating = 9,
                    Description = "Psychonauts 2 is everything I wanted a Psychonauts sequel to be. It delivers on a compelling new chapter of the story full of unique characters, tighter platforming, amazing combat for a platformer, and best of all: incredible new mind-themed worlds to explore. Unlike the original, Psychonauts 2 doesn’t suffer from inconsistent difficulty and flubbing level gimmicks. The worst I can say is that the pacing at the very end felt a little off and occasionally voice lines got interrupted, but if you’re a fan of collectathon platformers, or 3D platformers in general, I cannot recommend Psychonauts 2 enough."
                },
                new Review
                {
                    Created = DateTime.Now,
                    Id = 2,
                    Rating = 3
                },
                new Review
                {
                    Created = DateTime.Now,
                    Id = 3,
                    Rating = 8
                },
                new Review
                {
                    Created = DateTime.Now,
                    Id = 4,
                    Rating = 7
                },
                new Review
                {
                    Created = DateTime.Now,
                    Id = 5,
                    Rating = 6
                });
            modelBuilder.Entity<GameUser>().HasData(
                new GameUser
                {
                    GameId = 1,
                    ReviewId = 1,
                    UserId = "1"
                },
                new GameUser
                {
                    GameId = 7,
                    ReviewId = 2,
                    UserId = "1"
                },
                new GameUser
                {
                    GameId = 10,
                    ReviewId = 3,
                    UserId = "1"
                },
                new GameUser
                {
                    GameId = 4,
                    ReviewId = 4,
                    UserId = "1"
                },
                new GameUser 
                { 
                    GameId = 9,
                    UserId = "3"
                },
                new GameUser
                {
                    GameId = 5,
                    ReviewId = 5,
                    UserId = "1"
                });
            modelBuilder.Entity("GamePlatform").HasData(
                new { GamesId = 1, PlatformsId = 1 },
                new { GamesId = 1, PlatformsId = 2 },
                new { GamesId = 1, PlatformsId = 4 },

                new { GamesId = 2, PlatformsId = 1 },
                new { GamesId = 2, PlatformsId = 2 },
                
                new { GamesId = 3, PlatformsId = 1 },
                new { GamesId = 3, PlatformsId = 2 },
                new { GamesId = 3, PlatformsId = 3 },
                new { GamesId = 3, PlatformsId = 4 },

                new { GamesId = 4, PlatformsId = 1 },

                new { GamesId = 5, PlatformsId = 2 },

                new { GamesId = 6, PlatformsId = 3 },
                new { GamesId = 7, PlatformsId = 3 },
                new { GamesId = 8, PlatformsId = 3 },
                new { GamesId = 9, PlatformsId = 3 },

                new { GamesId = 10, PlatformsId = 1 },
                new { GamesId = 10, PlatformsId = 4 });
        }
    }
}
