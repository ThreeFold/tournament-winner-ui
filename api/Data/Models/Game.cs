namespace TournamentWinner.Api.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string BannerImage { get; set; }
    public string IconImage { get; set; }
    public ICollection<CharacterGame> CharacterGames { get; set; }
    public ICollection<CommunityGame> CommunityGames { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime InsertDate { get; set; }
}
