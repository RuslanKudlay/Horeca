using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucutre.Migrations
{
    /// <inheritdoc />
    public partial class AddedMenuContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "menu");

            migrationBuilder.CreateTable(
                name: "Menus",
                schema: "menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата створення"),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата оновлення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuGroups",
                schema: "menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата створення"),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата оновлення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuGroups_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "menu",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                schema: "menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Description"),
                    Price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Price"),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MenuGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата створення"),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата оновлення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuGroups_MenuGroupId",
                        column: x => x.MenuGroupId,
                        principalSchema: "menu",
                        principalTable: "MenuGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroups_MenuId",
                schema: "menu",
                table: "MenuGroups",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuGroupId",
                schema: "menu",
                table: "MenuItem",
                column: "MenuGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem",
                schema: "menu");

            migrationBuilder.DropTable(
                name: "MenuGroups",
                schema: "menu");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "menu");
        }
    }
}
