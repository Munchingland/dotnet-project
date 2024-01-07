using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    public partial class ChangeOnDeleteBehviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesUsers_Reviews_ReviewId",
                table: "GamesUsers");

            migrationBuilder.DropIndex(
                name: "IX_GamesUsers_ReviewId",
                table: "GamesUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e386a435-c1d1-47fd-b90d-4563fba4b141");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "33184132-47fb-442b-9d55-12e75c52dbad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "BirthDay", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 1, 7, 18, 38, 9, 110, DateTimeKind.Local).AddTicks(8493), "68260f73-eddc-4b70-bda5-39e0cff4b596", "AQAAAAEAACcQAAAAEIe9ewblJ+iRoTZhfnfcE6fPn6jUwhfWmJzZWaYltOC9QMwQo2Wx5B4I197/BT9xFw==", "cfed15af-f09a-429b-bbd9-ebdc25408972" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "333be91f-2d8a-4a61-84e4-f1bcc6bf6cad", "AQAAAAEAACcQAAAAEOlevlg0Tc3orLjuExWIAGcBFr6jqjpLgphAeiYwnJkaDtifEYBhhnE6D2SSqEjWsg==", "b32c6a64-2016-4b8c-852e-de4f3d15e1b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68ab2141-e29c-46a8-8cbe-c868f108f537", "AQAAAAEAACcQAAAAEGUm/4ntH68lx7Rsh3O2AFjahj5Js3hal99S0MZg6fdnZgpiy/MxydDUDpyfwaShAA==", "ef5a2f9d-fa2f-4b10-8f1f-b2bf81deac89" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 7, 18, 38, 9, 113, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 7, 18, 38, 9, 113, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 7, 18, 38, 9, 113, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 7, 18, 38, 9, 113, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 1, 7, 18, 38, 9, 113, DateTimeKind.Local).AddTicks(6633));

            migrationBuilder.CreateIndex(
                name: "IX_GamesUsers_ReviewId",
                table: "GamesUsers",
                column: "ReviewId",
                unique: true,
                filter: "[ReviewId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesUsers_Reviews_ReviewId",
                table: "GamesUsers",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesUsers_Reviews_ReviewId",
                table: "GamesUsers");

            migrationBuilder.DropIndex(
                name: "IX_GamesUsers_ReviewId",
                table: "GamesUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "49c94ebb-2b17-4e6b-861d-e8854dc22a1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e6c8c437-73c6-4bd7-a266-30a4747fdb8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "BirthDay", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 27, 1, 12, DateTimeKind.Local).AddTicks(830), "44e513c7-a99f-4dd0-bf03-e28c58f0e011", "AQAAAAEAACcQAAAAEL91kYNuCnIXF5IrlhyBTFMPZL+gFAH0hjEyIYpyLkujBzczuLGAP/Ce6TLzF4M/ww==", "7d6ca299-9a98-47e1-89cb-59af1182ac7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "004443f1-9d88-4824-88d1-465a9ca92b8c", "AQAAAAEAACcQAAAAEPF6hYejeC+5vusO+LS7aGv51xa1K8k1LJ9JGPxpbBWxHcybG/xIW+XoO8i6G9awsw==", "24cbd802-c1b1-4e7f-8a5c-b19eec90797c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfad7ab2-1654-4d59-b0b2-44bfd12b8f69", "AQAAAAEAACcQAAAAEJuwhPaDmWajyqjlFvk6DK6+dGqJxGa3bmFpxvLiQCaMb9C8Is/EiIqcYINlx7+Xxw==", "8b7549bf-006e-462b-bead-39ffab16daba" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.CreateIndex(
                name: "IX_GamesUsers_ReviewId",
                table: "GamesUsers",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesUsers_Reviews_ReviewId",
                table: "GamesUsers",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id");
        }
    }
}
