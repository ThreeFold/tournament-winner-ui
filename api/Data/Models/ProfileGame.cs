namespace TournamentWinner.Api.Models;

public class ProfileGame {
    public int ProfileGameId {get;set;}
    public int GameId {get;set;}
    public string UserId {get;set;}
    public Game Game {get;set;}
    public Profile Profile {get;set;}
    public ICollection<ProfileGameCharacter> Characters {get;set;}
    public DateTime InsertDate {get;set;}
}
