using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class DefaultId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "users",
                type: "text",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "gen_random_uuid()");
        }
    }
}
