using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class FixGameCharacterRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGame_characters_CharactersCharacterId",
                table: "CharacterGame");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGame_games_GamesGameId",
                table: "CharacterGame");

            migrationBuilder.DropTable(
                name: "characterGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterGame",
                table: "CharacterGame");

            migrationBuilder.RenameTable(
                name: "CharacterGame",
                newName: "characterGame");

            migrationBuilder.RenameColumn(
                name: "GamesGameId",
                table: "characterGame",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "CharactersCharacterId",
                table: "characterGame",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterGame_GamesGameId",
                table: "characterGame",
                newName: "IX_characterGame_GameId");

            migrationBuilder.AddColumn<int>(
                name: "CharacterGameId",
                table: "characterGame",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "characterGame",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "UniqueIdentifier",
                table: "characterGame",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_characterGame",
                table: "characterGame",
                column: "CharacterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_characterGame_CharacterId",
                table: "characterGame",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_characterGame_characters_CharacterId",
                table: "characterGame",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_characterGame_games_GameId",
                table: "characterGame",
                column: "GameId",
                principalTable: "games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characterGame_characters_CharacterId",
                table: "characterGame");

            migrationBuilder.DropForeignKey(
                name: "FK_characterGame_games_GameId",
                table: "characterGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_characterGame",
                table: "characterGame");

            migrationBuilder.DropIndex(
                name: "IX_characterGame_CharacterId",
                table: "characterGame");

            migrationBuilder.DropColumn(
                name: "CharacterGameId",
                table: "characterGame");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "characterGame");

            migrationBuilder.DropColumn(
                name: "UniqueIdentifier",
                table: "characterGame");

            migrationBuilder.RenameTable(
                name: "characterGame",
                newName: "CharacterGame");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "CharacterGame",
                newName: "GamesGameId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterGame",
                newName: "CharactersCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_characterGame_GameId",
                table: "CharacterGame",
                newName: "IX_CharacterGame_GamesGameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterGame",
                table: "CharacterGame",
                columns: new[] { "CharactersCharacterId", "GamesGameId" });

            migrationBuilder.CreateTable(
                name: "characterGame",
                columns: table => new
                {
                    CharacterGameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UniqueIdentifier = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characterGame", x => x.CharacterGameId);
                    table.ForeignKey(
                        name: "FK_characterGame_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characterGame_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_characterGame_CharacterId",
                table: "characterGame",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_characterGame_GameId",
                table: "characterGame",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGame_characters_CharactersCharacterId",
                table: "CharacterGame",
                column: "CharactersCharacterId",
                principalTable: "characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGame_games_GamesGameId",
                table: "CharacterGame",
                column: "GamesGameId",
                principalTable: "games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
