﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameUser> GamesUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameUser>().HasKey(t => new { t.UserId, t.GameId });
            builder.Entity<Review>().HasOne(r => r.User).WithOne(u => u.Review).OnDelete(DeleteBehavior.SetNull);

            Seeder.Seed(builder);
            base.OnModelCreating(builder);
        }
    }
}
