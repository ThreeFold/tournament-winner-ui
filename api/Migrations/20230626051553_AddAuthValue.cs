using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthValue",
                table: "userAuthMethods",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthValue",
                table: "userAuthMethods");
        }
    }
}
