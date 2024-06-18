using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Love.Migrations
{
    /// <inheritdoc />
    public partial class TokensMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "MainUserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "MainUserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "MainUserInfo");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "MainUserInfo");
        }
    }
}
