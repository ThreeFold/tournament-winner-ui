using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class Cleanpu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_communities_users_OwnerUserId",
                table: "communities");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_players_Player1Id",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_players_Player2Id",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_players_communities_CommunityId",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "FK_players_userGames_ProfileGameId",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "FK_ranks_players_PlayerId",
                table: "ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_userGames_profiles_ProfileId",
                table: "userGames");

            migrationBuilder.DropTable(
                name: "communityUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_players_CommunityId",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_players_ProfileGameId",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_communityUsers",
                table: "communityUsers");

            migrationBuilder.DropIndex(
                name: "IX_communities_OwnerUserId",
                table: "communities");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "players");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "players");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileGameId",
                table: "userGames",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileGameCharacterId",
                table: "userCharacters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserAuthMethodId",
                table: "userAuthMethods",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RankId",
                table: "ranks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RankingId",
                table: "rankings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "profiles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileGameId",
                table: "players",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "leagues",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GameSetId",
                table: "gameSets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "games",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommunityUserId",
                table: "communityUsers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "CommunityGameId",
                table: "communityGames",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "communities",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "communities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CharacterGameId",
                table: "characterGame",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CharacterAlternateNameId",
                table: "CharacterAlternateName",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "character",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BracketId",
                table: "brackets",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "userGames",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "players",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "communityUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "communityUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "communities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegionState",
                table: "communities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_communityUsers",
                table: "communityUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommunityGamePlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    CommunityGameId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityGamePlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityGamePlayer_communityGames_CommunityGameId",
                        column: x => x.CommunityGameId,
                        principalTable: "communityGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityGamePlayer_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityGamePlayer_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityGamePlayer_CommunityGameId",
                table: "CommunityGamePlayer",
                column: "CommunityGameId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityGamePlayer_PlayerId",
                table: "CommunityGamePlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityGamePlayer_UserId",
                table: "CommunityGamePlayer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_players_Player1Id",
                table: "gameSets",
                column: "Player1Id",
                principalTable: "players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_players_Player2Id",
                table: "gameSets",
                column: "Player2Id",
                principalTable: "players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ranks_players_PlayerId",
                table: "ranks",
                column: "PlayerId",
                principalTable: "players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userGames_profiles_ProfileId",
                table: "userGames",
                column: "ProfileId",
                principalTable: "profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_players_Player1Id",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_gameSets_players_Player2Id",
                table: "gameSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ranks_players_PlayerId",
                table: "ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_userGames_profiles_ProfileId",
                table: "userGames");

            migrationBuilder.DropTable(
                name: "CommunityGamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_communityUsers",
                table: "communityUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "communityUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "communities");

            migrationBuilder.DropColumn(
                name: "RegionState",
                table: "communities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "userGames",
                newName: "ProfileGameId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "userCharacters",
                newName: "ProfileGameCharacterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "userAuthMethods",
                newName: "UserAuthMethodId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ranks",
                newName: "RankId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rankings",
                newName: "RankingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "profiles",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "players",
                newName: "ProfileGameId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "leagues",
                newName: "LeagueId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "gameSets",
                newName: "GameSetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "games",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "communityUsers",
                newName: "CommunityUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "communityGames",
                newName: "CommunityGameId");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "communities",
                newName: "OwnerUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "communities",
                newName: "CommunityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "characterGame",
                newName: "CharacterGameId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CharacterAlternateName",
                newName: "CharacterAlternateNameId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "character",
                newName: "CharacterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "brackets",
                newName: "BracketId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "userGames",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileGameId",
                table: "players",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "players",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "players",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommunityUserId",
                table: "communityUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_communityUsers",
                table: "communityUsers",
                column: "CommunityUserId");

            migrationBuilder.CreateTable(
                name: "communityUserRoles",
                columns: table => new
                {
                    CommunityUserRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CommunityUserId = table.Column<int>(type: "integer", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    RoleType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communityUserRoles", x => x.CommunityUserRoleId);
                    table.ForeignKey(
                        name: "FK_communityUserRoles_communityUsers_CommunityUserId",
                        column: x => x.CommunityUserId,
                        principalTable: "communityUsers",
                        principalColumn: "CommunityUserId");
                    table.ForeignKey(
                        name: "FK_communityUserRoles_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_CommunityId",
                table: "players",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_players_ProfileGameId",
                table: "players",
                column: "ProfileGameId");

            migrationBuilder.CreateIndex(
                name: "IX_communities_OwnerUserId",
                table: "communities",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_communityUserRoles_CommunityUserId",
                table: "communityUserRoles",
                column: "CommunityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_communityUserRoles_UserId",
                table: "communityUserRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_communities_users_OwnerUserId",
                table: "communities",
                column: "OwnerUserId",
                principalTable: "users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_players_Player1Id",
                table: "gameSets",
                column: "Player1Id",
                principalTable: "players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameSets_players_Player2Id",
                table: "gameSets",
                column: "Player2Id",
                principalTable: "players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_players_communities_CommunityId",
                table: "players",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_players_userGames_ProfileGameId",
                table: "players",
                column: "ProfileGameId",
                principalTable: "userGames",
                principalColumn: "ProfileGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ranks_players_PlayerId",
                table: "ranks",
                column: "PlayerId",
                principalTable: "players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userGames_profiles_ProfileId",
                table: "userGames",
                column: "ProfileId",
                principalTable: "profiles",
                principalColumn: "ProfileId");
        }
    }
}
