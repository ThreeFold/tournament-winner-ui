using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class GameCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_games_GameId",
                table: "characters");

            migrationBuilder.DropIndex(
                name: "IX_characters_GameId",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "characters");

            migrationBuilder.CreateTable(
                name: "CharacterGame",
                columns: table => new
                {
                    CharactersCharacterId = table.Column<int>(type: "integer", nullable: false),
                    GamesGameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterGame", x => new { x.CharactersCharacterId, x.GamesGameId });
                    table.ForeignKey(
                        name: "FK_CharacterGame_characters_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalTable: "characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterGame_games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterGame_GamesGameId",
                table: "CharacterGame",
                column: "GamesGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterGame");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "characters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_characters_GameId",
                table: "characters",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_games_GameId",
                table: "characters",
                column: "GameId",
                principalTable: "games",
                principalColumn: "GameId");
        }
    }
}
