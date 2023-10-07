using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Created", "Deleted", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(1986, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bethesda", null },
                    { 2, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Double Fine", null },
                    { 3, new DateTime(1986, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FromSoftware", null },
                    { 4, new DateTime(1989, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Game Freak", null },
                    { 5, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Santa Monica Studios", null }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Created", "Deleted", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Steam", null },
                    { 2, new DateTime(2013, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Playstation 4", null },
                    { 3, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nintendo Switch", null },
                    { 4, new DateTime(2013, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xbox One S", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Created", "Deleted", "Description", "Rating", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2907), null, "Psychonauts 2 is everything I wanted a Psychonauts sequel to be. It delivers on a compelling new chapter of the story full of unique characters, tighter platforming, amazing combat for a platformer, and best of all: incredible new mind-themed worlds to explore. Unlike the original, Psychonauts 2 doesn’t suffer from inconsistent difficulty and flubbing level gimmicks. The worst I can say is that the pacing at the very end felt a little off and occasionally voice lines got interrupted, but if you’re a fan of collectathon platformers, or 3D platformers in general, I cannot recommend Psychonauts 2 enough.", 9, null },
                    { 2, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2910), null, null, 3, null },
                    { 3, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2911), null, null, 8, null },
                    { 4, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2913), null, null, 7, null },
                    { 5, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2914), null, null, 6, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Deleted", "Email", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2857), null, "Jarno.Caenepeel@student.howest.com", "Jarno Caenepeel", null },
                    { 2, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2887), null, "lipsum@hotmail.com", "lorem ipsum", null },
                    { 3, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2889), null, "George@hotmail.com", "George O. Estrada", null },
                    { 4, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2891), null, "Enos@hotmail.com", "Enos White", null },
                    { 5, new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2892), null, "Mable@gmail.com", "Mable Parisian", null }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Created", "Deleted", "DeveloperId", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Psychonauts 2", null },
                    { 2, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "God of War", null },
                    { 3, new DateTime(2018, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Dark Souls: Remastered", null },
                    { 4, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Elden Ring", null },
                    { 5, new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Bloodborne", null },
                    { 6, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Pokemon Scarlet", null },
                    { 7, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Pokemon Violet", null },
                    { 8, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Pokemon Sword", null },
                    { 9, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Pokemon Shield", null },
                    { 10, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Starfield", null }
                });

            migrationBuilder.InsertData(
                table: "GamePlatform",
                columns: new[] { "GamesId", "PlatformsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 1 },
                    { 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "GamesUsers",
                columns: new[] { "GameId", "UserId", "ReviewId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 7, 1, 4 },
                    { 10, 2, 4 },
                    { 4, 4, 5 },
                    { 4, 5, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
