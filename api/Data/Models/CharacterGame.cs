namespace TournamentWinner.Api.Models;

public class CharacterGame {
    public int CharacterGameId {get;set;}
    public int CharacterId {get;set;}
    public int GameId {get;set;}    
    public string? UniqueIdentifier {get;set;}
    public DateTime InsertDate {get;set;}
    public Game Game {get;set;}
    public Character Character {get;set;}
}
