using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.GameLibrary.Infrastructure.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasApprovedTermsAndConditions = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    PlatformsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesUsers",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesUsers", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GamesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesUsers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesUsers_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "49c94ebb-2b17-4e6b-861d-e8854dc22a1f", "Admin", "ADMIN" },
                    { "2", "e6c8c437-73c6-4bd7-a266-30a4747fdb8c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "HasApprovedTermsAndConditions", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, new DateTime(2023, 11, 10, 15, 27, 1, 12, DateTimeKind.Local).AddTicks(830), "44e513c7-a99f-4dd0-bf03-e28c58f0e011", "user@pri.be", false, true, false, null, "USER@PRI.BE", "PRIUSER", "AQAAAAEAACcQAAAAEL91kYNuCnIXF5IrlhyBTFMPZL+gFAH0hjEyIYpyLkujBzczuLGAP/Ce6TLzF4M/ww==", null, false, "7d6ca299-9a98-47e1-89cb-59af1182ac7c", false, "PriUser" },
                    { "2", 0, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "004443f1-9d88-4824-88d1-465a9ca92b8c", "refuser@pri.be", false, false, false, null, "REFUSER@PRI.BE", "PRIREFUSER", "AQAAAAEAACcQAAAAEPF6hYejeC+5vusO+LS7aGv51xa1K8k1LJ9JGPxpbBWxHcybG/xIW+XoO8i6G9awsw==", null, false, "24cbd802-c1b1-4e7f-8a5c-b19eec90797c", false, "PriRefuser" },
                    { "3", 0, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfad7ab2-1654-4d59-b0b2-44bfd12b8f69", "admin@pri.be", false, null, false, null, "ADMIN@PRI.BE", "PRIADMIN", "AQAAAAEAACcQAAAAEJuwhPaDmWajyqjlFvk6DK6+dGqJxGa3bmFpxvLiQCaMb9C8Is/EiIqcYINlx7+Xxw==", null, false, "8b7549bf-006e-462b-bead-39ffab16daba", false, "PriAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1986, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bethesda" },
                    { 2, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Double Fine" },
                    { 3, new DateTime(1986, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FromSoftware" },
                    { 4, new DateTime(1989, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game Freak" },
                    { 5, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santa Monica Studios" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steam" },
                    { 2, new DateTime(2013, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Playstation 4" },
                    { 3, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nintendo Switch" },
                    { 4, new DateTime(2013, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xbox One S" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Created", "Description", "Rating" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8704), "Psychonauts 2 is everything I wanted a Psychonauts sequel to be. It delivers on a compelling new chapter of the story full of unique characters, tighter platforming, amazing combat for a platformer, and best of all: incredible new mind-themed worlds to explore. Unlike the original, Psychonauts 2 doesn’t suffer from inconsistent difficulty and flubbing level gimmicks. The worst I can say is that the pacing at the very end felt a little off and occasionally voice lines got interrupted, but if you’re a fan of collectathon platformers, or 3D platformers in general, I cannot recommend Psychonauts 2 enough.", 9 },
                    { 2, new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8708), null, 3 },
                    { 3, new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8710), null, 8 },
                    { 4, new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8712), null, 7 },
                    { 5, new DateTime(2023, 11, 10, 15, 27, 1, 14, DateTimeKind.Local).AddTicks(8713), null, 6 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "1" },
                    { "2", "2" },
                    { "1", "3" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Created", "DeveloperId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Psychonauts 2" },
                    { 2, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "God of War" },
                    { 3, new DateTime(2018, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Dark Souls: Remastered" },
                    { 4, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Elden Ring" },
                    { 5, new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bloodborne" },
                    { 6, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Pokemon Scarlet" },
                    { 7, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Pokemon Violet" },
                    { 8, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Pokemon Sword" },
                    { 9, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Pokemon Shield" },
                    { 10, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Starfield" }
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
                    { 1, "1", 1 },
                    { 4, "1", 4 },
                    { 5, "1", 5 },
                    { 7, "1", 2 },
                    { 10, "1", 3 },
                    { 9, "3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesUsers_GameId",
                table: "GamesUsers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesUsers_ReviewId",
                table: "GamesUsers",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GamesUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
