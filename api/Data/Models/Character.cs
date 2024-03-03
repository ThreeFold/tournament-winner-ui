namespace TournamentWinner.Api.Models;

public class Character {
    public int Id {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public ICollection<CharacterAlternateName> AlternateNames {get;set;}
    public DateTime InsertDate {get;set;}
    public ICollection<CharacterGame> CharacterGames {get;set;}
}
