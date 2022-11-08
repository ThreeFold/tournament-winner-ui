using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace twapi.Migrations
{
    public partial class CommunityRefFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_communityGames_communities_CommunityId",
                table: "communityGames");

            migrationBuilder.DropForeignKey(
                name: "FK_communityUsers_communities_CommunityId",
                table: "communityUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_players_communities_CommunityID",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_communities",
                table: "communities");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "communities");

            migrationBuilder.RenameColumn(
                name: "CommunityID",
                table: "players",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_players_CommunityID",
                table: "players",
                newName: "IX_players_CommunityId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "communities",
                newName: "CommunityId");

            migrationBuilder.AlterColumn<int>(
                name: "CommunityId",
                table: "communities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_communities",
                table: "communities",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_communityGames_communities_CommunityId",
                table: "communityGames",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_communityUsers_communities_CommunityId",
                table: "communityUsers",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_players_communities_CommunityId",
                table: "players",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "CommunityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_communityGames_communities_CommunityId",
                table: "communityGames");

            migrationBuilder.DropForeignKey(
                name: "FK_communityUsers_communities_CommunityId",
                table: "communityUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_players_communities_CommunityId",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_communities",
                table: "communities");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "players",
                newName: "CommunityID");

            migrationBuilder.RenameIndex(
                name: "IX_players_CommunityId",
                table: "players",
                newName: "IX_players_CommunityID");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "communities",
                newName: "OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "communities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "communities",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_communities",
                table: "communities",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_communityGames_communities_CommunityId",
                table: "communityGames",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_communityUsers_communities_CommunityId",
                table: "communityUsers",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_players_communities_CommunityID",
                table: "players",
                column: "CommunityID",
                principalTable: "communities",
                principalColumn: "ID");
        }
    }
}
