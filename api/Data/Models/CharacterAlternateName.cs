namespace TournamentWinner.Api.Models;

public class CharacterAlternateName
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public string? AlternateName { get; set; }

    public Character Character { get; set; }
}
