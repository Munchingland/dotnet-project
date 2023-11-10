using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Users",
                newName: "BirthDay");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasApprovedTermsAndConditions",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GamesUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 10, 14, 36, 53, 803, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 10, 14, 36, 53, 803, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 11, 10, 14, 36, 53, 803, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 11, 10, 14, 36, 53, 803, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 11, 10, 14, 36, 53, 803, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "HasApprovedTermsAndConditions", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, new DateTime(2023, 11, 10, 14, 36, 53, 801, DateTimeKind.Local).AddTicks(180), "fad8249b-f63c-4712-b958-775d1cc46b9c", "user@pri.be", false, true, false, null, "USER@PRI.BE", "PRIUSER", "AQAAAAEAACcQAAAAEAUUtpBkONRLCmkSqrgVDn2Qk/3aVqHtylTZeHMUC9FyMZls1za1I/SxOVTibSRXpg==", null, false, "b32cfec8-2ca9-4a29-aad1-b35d3c8161b9", false, "PriUser" },
                    { "2", 0, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "4e86be87-90e0-4490-ac1c-25c3ba6000ef", "refuser@pri.be", false, false, false, null, "REFUSER@PRI.BE", "PRIREFUSER", "AQAAAAEAACcQAAAAEI8OE0mJ4gKLX6YOfXelfMJFyTSAz/AdPGFh6+Pr01Ukqld4JrIqwpZCxcSAX0PRvw==", null, false, "c47c728b-bffb-49cc-95bd-65225949d7d3", false, "PriRefuser" },
                    { "3", 0, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "f8b29e74-9b56-464b-b902-3920144f3f21", "admin@pri.be", false, null, false, null, "ADMIN@PRI.BE", "PRIADMIN", "AQAAAAEAACcQAAAAEKlhP52uTtdrUH1skpaGI5X4qY3gn10nRX2XXF6t4sW4R1gkmrByAQ90919HHI2xWw==", null, false, "a9fe19dc-4adf-4a9e-b59a-77afebc1d8cb", false, "PriAdmin" }
                });

            migrationBuilder.InsertData(
                table: "GamesUsers",
                columns: new[] { "GameId", "UserId", "ReviewId" },
                values: new object[,]
                {
                    { 1, "1", 1 },
                    { 4, "1", 4 },
                    { 5, "1", 5 },
                    { 7, "1", 2 },
                    { 10, "1", 3 },
                    { 9, "3", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 1, "1" });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 4, "1" });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 5, "1" });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 7, "1" });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 10, "1" });

            migrationBuilder.DeleteData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 9, "3" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasApprovedTermsAndConditions",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "Users",
                newName: "Created");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GamesUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(8992), "Jarno.Caenepeel@student.howest.com", "Jarno Caenepeel" },
                    { 2, new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9023), "lipsum@hotmail.com", "lorem ipsum" },
                    { 3, new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9026), "George@hotmail.com", "George O. Estrada" },
                    { 4, new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9027), "Enos@hotmail.com", "Enos White" },
                    { 5, new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9029), "Mable@gmail.com", "Mable Parisian" }
                });

            migrationBuilder.InsertData(
                table: "GamesUsers",
                columns: new[] { "GameId", "UserId", "ReviewId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 7, 1, 2 },
                    { 10, 2, 3 },
                    { 4, 4, 5 },
                    { 4, 5, 4 }
                });
        }
    }
}
