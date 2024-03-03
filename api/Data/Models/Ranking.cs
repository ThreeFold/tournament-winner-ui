namespace TournamentWinner.Api.Models;

public class Ranking {
    public int Id {get;set;}
    public string Name {get;set;}
    public int CommunityGameId {get;set;}
    public DateTime PeriodStart {get;set;}
    public DateTime? PeriodEnd {get;set;}
    public DateTime InsertDate {get;set;}
    public ICollection<Rank> Ranks {get;set;}
    public CommunityGame CommunityGame {get;set;}
}
