namespace TournamentWinner.Api.Models;

public class Bracket
{
    public int Id { get; set; }
    public ICollection<GameSet> Sets { get; set; }
    public DateTime InsertDate { get; set; }
}
