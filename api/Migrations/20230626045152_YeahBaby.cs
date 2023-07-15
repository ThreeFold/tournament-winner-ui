using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class YeahBaby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsernamePrefix",
                table: "users",
                newName: "Prefix");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "userAuthMethods",
                columns: table => new
                {
                    UserAuthMethodId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AuthMethod = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAuthMethods", x => x.UserAuthMethodId);
                    table.ForeignKey(
                        name: "FK_userAuthMethods_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userAuthMethods_UserId",
                table: "userAuthMethods",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userAuthMethods");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Prefix",
                table: "users",
                newName: "UsernamePrefix");
        }
    }
}
