using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twapi.Migrations
{
    /// <inheritdoc />
    public partial class CommunityUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_communities_Name",
                table: "communities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_communities_Slug",
                table: "communities",
                column: "Slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_communities_Name",
                table: "communities");

            migrationBuilder.DropIndex(
                name: "IX_communities_Slug",
                table: "communities");
        }
    }
}
