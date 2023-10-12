using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    public partial class UpdateSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 7, 1 },
                column: "ReviewId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 10, 2 },
                column: "ReviewId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 10, 12, 13, 6, 24, 137, DateTimeKind.Local).AddTicks(7999));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 7, 1 },
                column: "ReviewId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "GamesUsers",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 10, 2 },
                column: "ReviewId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 10, 7, 15, 18, 32, 904, DateTimeKind.Local).AddTicks(2892));
        }
    }
}
