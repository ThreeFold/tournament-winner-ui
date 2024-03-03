using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BannerImage = table.Column<string>(type: "text", nullable: false),
                    IconImage = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    UserCreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

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

            migrationBuilder.CreateTable(
                name: "characterGame",
                columns: table => new
                {
                    CharacterGameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    UniqueIdentifier = table.Column<string>(type: "text", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characterGame", x => x.CharacterGameId);
                    table.ForeignKey(
                        name: "FK_characterGame_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characterGame_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "communities",
                columns: table => new
                {
                    CommunityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OwnerUserId = table.Column<string>(type: "text", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communities", x => x.CommunityId);
                    table.ForeignKey(
                        name: "FK_communities_users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    Handle = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_profiles_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "userAuthMethods",
                columns: table => new
                {
                    UserAuthMethodId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AuthValue = table.Column<string>(type: "text", nullable: false),
                    AuthProviderId = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "communityGames",
                columns: table => new
                {
                    CommunityGameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommunityId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communityGames", x => x.CommunityGameId);
                    table.ForeignKey(
                        name: "FK_communityGames_communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_communityGames_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "communityUsers",
                columns: table => new
                {
                    CommunityUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommunityId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communityUsers", x => x.CommunityUserId);
                    table.ForeignKey(
                        name: "FK_communityUsers_communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_communityUsers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userGames",
                columns: table => new
                {
                    ProfileGameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGames", x => x.ProfileGameId);
                    table.ForeignKey(
                        name: "FK_userGames_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userGames_profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateTable(
                name: "brackets",
                columns: table => new
                {
                    BracketId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CommunityGameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brackets", x => x.BracketId);
                    table.ForeignKey(
                        name: "FK_brackets_communityGames_CommunityGameId",
                        column: x => x.CommunityGameId,
                        principalTable: "communityGames",
                        principalColumn: "CommunityGameId");
                });

            migrationBuilder.CreateTable(
                name: "leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Homepage = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CommunityGameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leagues", x => x.LeagueId);
                    table.ForeignKey(
                        name: "FK_leagues_communityGames_CommunityGameId",
                        column: x => x.CommunityGameId,
                        principalTable: "communityGames",
                        principalColumn: "CommunityGameId");
                });

            migrationBuilder.CreateTable(
                name: "rankings",
                columns: table => new
                {
                    RankingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CommunityGameId = table.Column<int>(type: "integer", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rankings", x => x.RankingId);
                    table.ForeignKey(
                        name: "FK_rankings_communityGames_CommunityGameId",
                        column: x => x.CommunityGameId,
                        principalTable: "communityGames",
                        principalColumn: "CommunityGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "communityUserRoles",
                columns: table => new
                {
                    CommunityUserRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleType = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CommunityUserId = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProfileGameId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CommunityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_players_communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "communities",
                        principalColumn: "CommunityId");
                    table.ForeignKey(
                        name: "FK_players_userGames_ProfileGameId",
                        column: x => x.ProfileGameId,
                        principalTable: "userGames",
                        principalColumn: "ProfileGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCharacters",
                columns: table => new
                {
                    ProfileGameCharacterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileGameId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCharacters", x => x.ProfileGameCharacterId);
                    table.ForeignKey(
                        name: "FK_userCharacters_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userCharacters_userGames_ProfileGameId",
                        column: x => x.ProfileGameId,
                        principalTable: "userGames",
                        principalColumn: "ProfileGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gameSets",
                columns: table => new
                {
                    GameSetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BracketId = table.Column<int>(type: "integer", nullable: false),
                    Player1Id = table.Column<int>(type: "integer", nullable: false),
                    Player1CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Player2Id = table.Column<int>(type: "integer", nullable: false),
                    Player2CharacterId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameSets", x => x.GameSetId);
                    table.ForeignKey(
                        name: "FK_gameSets_brackets_BracketId",
                        column: x => x.BracketId,
                        principalTable: "brackets",
                        principalColumn: "BracketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameSets_character_Player1CharacterId",
                        column: x => x.Player1CharacterId,
                        principalTable: "character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameSets_character_Player2CharacterId",
                        column: x => x.Player2CharacterId,
                        principalTable: "character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameSets_players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameSets_players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    RankValue = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    RankingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranks", x => x.RankId);
                    table.ForeignKey(
                        name: "FK_ranks_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ranks_rankings_RankingId",
                        column: x => x.RankingId,
                        principalTable: "rankings",
                        principalColumn: "RankingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_brackets_CommunityGameId",
                table: "brackets",
                column: "CommunityGameId");

            migrationBuilder.CreateIndex(
                name: "IX_character_Name",
                table: "character",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAlternateName_CharacterId",
                table: "CharacterAlternateName",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_characterGame_CharacterId",
                table: "characterGame",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_characterGame_GameId",
                table: "characterGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_communities_OwnerUserId",
                table: "communities",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_communityGames_CommunityId",
                table: "communityGames",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_communityGames_GameId",
                table: "communityGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_communityUserRoles_CommunityUserId",
                table: "communityUserRoles",
                column: "CommunityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_communityUserRoles_UserId",
                table: "communityUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_communityUsers_CommunityId",
                table: "communityUsers",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_communityUsers_UserId",
                table: "communityUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_gameSets_BracketId",
                table: "gameSets",
                column: "BracketId");

            migrationBuilder.CreateIndex(
                name: "IX_gameSets_Player1CharacterId",
                table: "gameSets",
                column: "Player1CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_gameSets_Player1Id",
                table: "gameSets",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_gameSets_Player2CharacterId",
                table: "gameSets",
                column: "Player2CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_gameSets_Player2Id",
                table: "gameSets",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_leagues_CommunityGameId",
                table: "leagues",
                column: "CommunityGameId");

            migrationBuilder.CreateIndex(
                name: "IX_players_CommunityId",
                table: "players",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_players_ProfileGameId",
                table: "players",
                column: "ProfileGameId");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_UserId",
                table: "profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rankings_CommunityGameId",
                table: "rankings",
                column: "CommunityGameId");

            migrationBuilder.CreateIndex(
                name: "IX_ranks_PlayerId",
                table: "ranks",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ranks_RankingId",
                table: "ranks",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_userAuthMethods_UserId",
                table: "userAuthMethods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userCharacters_CharacterId",
                table: "userCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_userCharacters_ProfileGameId",
                table: "userCharacters",
                column: "ProfileGameId");

            migrationBuilder.CreateIndex(
                name: "IX_userGames_GameId",
                table: "userGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_userGames_ProfileId",
                table: "userGames",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAlternateName");

            migrationBuilder.DropTable(
                name: "characterGame");

            migrationBuilder.DropTable(
                name: "communityUserRoles");

            migrationBuilder.DropTable(
                name: "gameSets");

            migrationBuilder.DropTable(
                name: "leagues");

            migrationBuilder.DropTable(
                name: "ranks");

            migrationBuilder.DropTable(
                name: "userAuthMethods");

            migrationBuilder.DropTable(
                name: "userCharacters");

            migrationBuilder.DropTable(
                name: "communityUsers");

            migrationBuilder.DropTable(
                name: "brackets");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "rankings");

            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "userGames");

            migrationBuilder.DropTable(
                name: "communityGames");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "communities");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
