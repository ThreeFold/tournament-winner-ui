using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class CommunityGameIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "games",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "games");

            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "games");
        }
    }
}
