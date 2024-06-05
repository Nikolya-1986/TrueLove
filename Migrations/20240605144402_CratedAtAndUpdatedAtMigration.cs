using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Love.Migrations
{
    /// <inheritdoc />
    public partial class CratedAtAndUpdatedAtMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                table: "MainUserInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MainUserInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MainUserInfo",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MainUserInfo");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MainUserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                table: "MainUserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
