using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace twapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsernamePrefix = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    PlayerCreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    GameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_characters_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "communities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_communities_users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userGames",
                columns: table => new
                {
                    UserGameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGames", x => x.UserGameId);
                    table.ForeignKey(
                        name: "FK_userGames_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userGames_users_UserId",
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
                        principalColumn: "ID",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communityUsers", x => x.CommunityUserId);
                    table.ForeignKey(
                        name: "FK_communityUsers_communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "communities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_communityUsers_users_UserId",
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
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    UserGameId = table.Column<int>(type: "integer", nullable: false),
                    prefix = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CommunityID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_players_communities_CommunityID",
                        column: x => x.CommunityID,
                        principalTable: "communities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_players_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_players_userGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "userGames",
                        principalColumn: "UserGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCharacters",
                columns: table => new
                {
                    UserGameCharacterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserGameId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCharacters", x => x.UserGameCharacterId);
                    table.ForeignKey(
                        name: "FK_userCharacters_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userCharacters_userGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "userGames",
                        principalColumn: "UserGameId",
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_gameSets_characters_Player1CharacterId",
                        column: x => x.Player1CharacterId,
                        principalTable: "characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameSets_characters_Player2CharacterId",
                        column: x => x.Player2CharacterId,
                        principalTable: "characters",
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
                name: "IX_characters_GameId",
                table: "characters",
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
                name: "IX_players_CommunityID",
                table: "players",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_players_GameId",
                table: "players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_players_UserGameId",
                table: "players",
                column: "UserGameId");

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
                name: "IX_userCharacters_CharacterId",
                table: "userCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_userCharacters_UserGameId",
                table: "userCharacters",
                column: "UserGameId");

            migrationBuilder.CreateIndex(
                name: "IX_userGames_GameId",
                table: "userGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_userGames_UserId",
                table: "userGames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "communityUserRoles");

            migrationBuilder.DropTable(
                name: "gameSets");

            migrationBuilder.DropTable(
                name: "leagues");

            migrationBuilder.DropTable(
                name: "ranks");

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
                name: "characters");

            migrationBuilder.DropTable(
                name: "userGames");

            migrationBuilder.DropTable(
                name: "communityGames");

            migrationBuilder.DropTable(
                name: "communities");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
