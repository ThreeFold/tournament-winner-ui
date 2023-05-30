using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterNameIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characterGame_characters_CharacterId",
                table: "characterGame");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_characters_Player1CharacterId",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_characters_Player2CharacterId",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_userCharacters_characters_CharacterId",
                table: "userCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_characters",
                table: "characters");

            migrationBuilder.RenameTable(
                name: "characters",
                newName: "character");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "character",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_character",
                table: "character",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_character_Name",
                table: "character",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_characterGame_character_CharacterId",
                table: "characterGame",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_character_Player1CharacterId",
                table: "gameSets",
                column: "Player1CharacterId",
                principalTable: "character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_character_Player2CharacterId",
                table: "gameSets",
                column: "Player2CharacterId",
                principalTable: "character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCharacters_character_CharacterId",
                table: "userCharacters",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characterGame_character_CharacterId",
                table: "characterGame");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_character_Player1CharacterId",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_character_Player2CharacterId",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_userCharacters_character_CharacterId",
                table: "userCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_character",
                table: "character");

            migrationBuilder.DropIndex(
                name: "IX_character_Name",
                table: "character");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "character");

            migrationBuilder.RenameTable(
                name: "character",
                newName: "characters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_characters",
                table: "characters",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_characterGame_characters_CharacterId",
                table: "characterGame",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_characters_Player1CharacterId",
                table: "gameSets",
                column: "Player1CharacterId",
                principalTable: "characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_characters_Player2CharacterId",
                table: "gameSets",
                column: "Player2CharacterId",
                principalTable: "characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCharacters_characters_CharacterId",
                table: "userCharacters",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
