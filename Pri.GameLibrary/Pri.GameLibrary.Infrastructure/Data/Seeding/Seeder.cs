using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pri.GameLibrary.Core.Entities;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform()
                {
                    Created = new DateTime(2003,09,12),
                    Name = "Steam",
                    Id = 1
                },
                new Platform()
                {
                    Created = new DateTime(2013,11,15),
                    Name = "Playstation 4",
                    Id = 2
                },
                new Platform()
                {
                    Created = new DateTime(2017,03,3),
                    Name = "Nintendo Switch",
                    Id = 3
                },
                new Platform()
                {
                    Created = new DateTime(2013, 08, 02),
                    Name = "Xbox One S",
                    Id = 4
                });
            
            modelBuilder.Entity<Developer>().HasData(
                new Developer()
                {
                    Created = new DateTime(1986, 06, 28),
                    Name = "Bethesda",
                    Id = 1
                },
                new Developer()
                {
                    Created = new DateTime(2000,07, 1),
                    Name = "Double Fine",
                    Id= 2
                },
                new Developer()
                {
                    Created = new DateTime(1986, 11, 1),
                    Name = "FromSoftware",
                    Id = 3
                },
                new Developer()
                {
                    Created = new DateTime(1989,04,26),
                    Name = "Game Freak",
                    Id = 4
                },
                new Developer()
                {
                    Created = new DateTime(1999,1,1),
                    Name = "Santa Monica Studios",
                    Id= 5
                });
            modelBuilder.Entity<Game>().HasData(
                new Game()
                {
                    Created = new DateTime(2021, 08, 25),
                    Id = 1,
                    Name = "Psychonauts 2",
                    DeveloperId = 2,
                },
                new Game()
                {
                    Created = new DateTime(2018,04,20),
                    Id = 2,
                    Name = "God of War",
                    DeveloperId = 5
                },
                new Game()
                {
                    Created = new DateTime(2018, 05, 23),
                    Id = 3,
                    Name = "Dark Souls: Remastered",
                    DeveloperId = 3
                },
                new Game()
                {
                    Created = new DateTime(2022, 02, 25),
                    Id = 4,
                    Name = "Elden Ring",
                    DeveloperId = 3
                },
                new Game()
                {
                    Created = new DateTime(2015, 03, 24),
                    Id = 5,
                    Name = "Bloodborne",
                    DeveloperId = 3
                },
                new Game()
                {
                    Created = new DateTime(2022, 11, 18),
                    Id=6,
                    Name= "Pokemon Scarlet",
                    DeveloperId = 4
                },
                new Game()
                {
                    Created = new DateTime(2022, 11, 18),
                    Id = 7,
                    Name = "Pokemon Violet",
                    DeveloperId = 4
                },
                new Game()
                {
                    Created = new DateTime(2019, 11, 15),
                    Id = 8,
                    Name = "Pokemon Sword",
                    DeveloperId = 4
                },
                new Game()
                {
                    Created = new DateTime(2019, 11, 15),
                    Id = 9,
                    Name = "Pokemon Shield",
                    DeveloperId = 4
                },
                new Game()
                {
                    Created = new DateTime(2023, 09, 6),
                    Id = 10,
                    Name = "Starfield",
                    DeveloperId = 1
                });
            
        }
    }
}
