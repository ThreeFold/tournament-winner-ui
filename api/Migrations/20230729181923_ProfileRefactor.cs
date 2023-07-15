using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class ProfileRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_players_games_GameId",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "FK_players_userGames_UserGameId",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "FK_userCharacters_userGames_UserGameId",
                table: "userCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_userGames_users_UserId",
                table: "userGames");

            migrationBuilder.DropIndex(
                name: "IX_userGames_UserId",
                table: "userGames");

            migrationBuilder.DropIndex(
                name: "IX_players_GameId",
                table: "players");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "players");

            migrationBuilder.RenameColumn(
                name: "PlayerCreationDate",
                table: "users",
                newName: "UserCreationDate");

            migrationBuilder.RenameColumn(
                name: "UserGameId",
                table: "userGames",
                newName: "ProfileGameId");

            migrationBuilder.RenameColumn(
                name: "UserGameId",
                table: "userCharacters",
                newName: "ProfileGameId");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "userCharacters",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "UserGameCharacterId",
                table: "userCharacters",
                newName: "ProfileGameCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_userCharacters_UserGameId",
                table: "userCharacters",
                newName: "IX_userCharacters_ProfileGameId");

            migrationBuilder.RenameColumn(
                name: "prefix",
                table: "players",
                newName: "Prefix");

            migrationBuilder.RenameColumn(
                name: "UserGameId",
                table: "players",
                newName: "ProfileGameId");

            migrationBuilder.RenameIndex(
                name: "IX_players_UserGameId",
                table: "players",
                newName: "IX_players_ProfileGameId");

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "userGames",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "players",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "players",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    Handle = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_userGames_ProfileId",
                table: "userGames",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_UserId",
                table: "profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_players_userGames_ProfileGameId",
                table: "players",
                column: "ProfileGameId",
                principalTable: "userGames",
                principalColumn: "ProfileGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCharacters_userGames_ProfileGameId",
                table: "userCharacters",
                column: "ProfileGameId",
                principalTable: "userGames",
                principalColumn: "ProfileGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userGames_profiles_ProfileId",
                table: "userGames",
                column: "ProfileId",
                principalTable: "profiles",
                principalColumn: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_players_userGames_ProfileGameId",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "FK_userCharacters_userGames_ProfileGameId",
                table: "userCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_userGames_profiles_ProfileId",
                table: "userGames");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_userGames_ProfileId",
                table: "userGames");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "userGames");

            migrationBuilder.RenameColumn(
                name: "UserCreationDate",
                table: "users",
                newName: "PlayerCreationDate");

            migrationBuilder.RenameColumn(
                name: "ProfileGameId",
                table: "userGames",
                newName: "UserGameId");

            migrationBuilder.RenameColumn(
                name: "ProfileGameId",
                table: "userCharacters",
                newName: "UserGameId");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "userCharacters",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "ProfileGameCharacterId",
                table: "userCharacters",
                newName: "UserGameCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_userCharacters_ProfileGameId",
                table: "userCharacters",
                newName: "IX_userCharacters_UserGameId");

            migrationBuilder.RenameColumn(
                name: "Prefix",
                table: "players",
                newName: "prefix");

            migrationBuilder.RenameColumn(
                name: "ProfileGameId",
                table: "players",
                newName: "UserGameId");

            migrationBuilder.RenameIndex(
                name: "IX_players_ProfileGameId",
                table: "players",
                newName: "IX_players_UserGameId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "prefix",
                table: "players",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "players",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userGames_UserId",
                table: "userGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_players_GameId",
                table: "players",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_players_games_GameId",
                table: "players",
                column: "GameId",
                principalTable: "games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_players_userGames_UserGameId",
                table: "players",
                column: "UserGameId",
                principalTable: "userGames",
                principalColumn: "UserGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCharacters_userGames_UserGameId",
                table: "userCharacters",
                column: "UserGameId",
                principalTable: "userGames",
                principalColumn: "UserGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userGames_users_UserId",
                table: "userGames",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
