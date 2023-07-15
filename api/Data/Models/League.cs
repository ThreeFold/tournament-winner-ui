namespace TournamentWinner.Api.Models;

public class League {
    public int LeagueId {get;set;}
    public string Name {get;set;}
    public Uri? Homepage {get;set;}
    public string? Description {get;set;}
    public DateTime InsertDate {get;set;}
}