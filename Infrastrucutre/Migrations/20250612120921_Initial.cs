using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucutre.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true, comment: "Ім'я користувача"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Email"),
                    Password = table.Column<string>(type: "text", nullable: false, comment: "Пароль користувача"),
                    Phone = table.Column<string>(type: "text", nullable: true, comment: "Номер телефону користувача"),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата створення"),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата оновлення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "auth");
        }
    }
}
