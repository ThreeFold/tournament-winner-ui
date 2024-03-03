namespace TournamentWinner.Api.Models;

public class Rank {
    public int Id {get;set;}
    public int PlayerId {get;set;}
    public Player Player {get;set;}
    public int RankValue {get;set;}
    public DateTime InsertDate {get;set;}
}
