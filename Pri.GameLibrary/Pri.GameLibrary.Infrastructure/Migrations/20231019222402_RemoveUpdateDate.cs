using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    public partial class RemoveUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Developers");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 10, 20, 0, 24, 1, 756, DateTimeKind.Local).AddTicks(9029));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Platforms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Platforms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Games",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Games",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Developers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Developers",
                type: "datetime2",
                nullable: true);

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
    }
}
