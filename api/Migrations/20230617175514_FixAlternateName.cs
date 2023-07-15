using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class FixAlternateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterAlternateName",
                columns: table => new
                {
                    CharacterAlternateNameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    AlternateName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAlternateName", x => x.CharacterAlternateNameId);
                    table.ForeignKey(
                        name: "FK_CharacterAlternateName_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAlternateName_CharacterId",
                table: "CharacterAlternateName",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAlternateName");
        }
    }
}
