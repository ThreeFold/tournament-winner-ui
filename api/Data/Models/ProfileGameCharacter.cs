namespace TournamentWinner.Api.Models;

public class ProfileGameCharacter {
    public int ProfileGameCharacterId {get;set;}
    public int ProfileGameId {get;set;}
    public int CharacterId {get;set;}
    public ProfileGame UserGame {get;set;}
    public Character Character {get;set;}
    public int Position {get;set;}
    public DateTime InsertDate {get;set;}
}
