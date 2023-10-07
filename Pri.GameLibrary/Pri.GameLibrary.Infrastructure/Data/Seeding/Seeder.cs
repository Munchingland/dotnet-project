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

            
        }
    }
}
