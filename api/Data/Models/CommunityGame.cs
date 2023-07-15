namespace TournamentWinner.Api.Models;

public class CommunityGame {
    public int CommunityGameId {get;set;}
    public int CommunityId {get;set;}
    public int GameId {get;set;}
    public Community Community {get;set;}
    public Game Game {get;set;}
    public ICollection<Ranking> Rankings {get;set;}
    public ICollection<League> Leagues {get;set;}
    public ICollection<Bracket> Brackets {get;set;}
    public DateTime InsertDate {get;set;}
}
