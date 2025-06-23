using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucutre.Migrations
{
    /// <inheritdoc />
    public partial class AddedParentForMenuGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "menu",
                table: "MenuGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroups_ParentId",
                schema: "menu",
                table: "MenuGroups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuGroups_MenuGroups_ParentId",
                schema: "menu",
                table: "MenuGroups",
                column: "ParentId",
                principalSchema: "menu",
                principalTable: "MenuGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuGroups_MenuGroups_ParentId",
                schema: "menu",
                table: "MenuGroups");

            migrationBuilder.DropIndex(
                name: "IX_MenuGroups_ParentId",
                schema: "menu",
                table: "MenuGroups");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "menu",
                table: "MenuGroups");
        }
    }
}
