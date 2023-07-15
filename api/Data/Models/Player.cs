namespace TournamentWinner.Api.Models;

public class Player {
    public int PlayerId {get;set;}
    public string? Prefix {get;set;}
    public string? Name {get;set;}
    public int ProfileGameId {get;set;}
    public ProfileGame? ProfileGame {get;set;}
    public DateTime InsertDate {get;set;}

}
