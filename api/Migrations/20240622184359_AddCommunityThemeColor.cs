using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class AddCommunityThemeColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ThemeColor_Blue",
                table: "communities",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ThemeColor_Green",
                table: "communities",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<float>(
                name: "ThemeColor_Opacity",
                table: "communities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<byte>(
                name: "ThemeColor_Red",
                table: "communities",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThemeColor_Blue",
                table: "communities");

            migrationBuilder.DropColumn(
                name: "ThemeColor_Green",
                table: "communities");

            migrationBuilder.DropColumn(
                name: "ThemeColor_Opacity",
                table: "communities");

            migrationBuilder.DropColumn(
                name: "ThemeColor_Red",
                table: "communities");
        }
    }
}
