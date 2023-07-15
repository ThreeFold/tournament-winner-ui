namespace TournamentWinner.Api.Models;
public class Community {
    public int CommunityId {get;set; }
    public string Name {get;set;}
    public string? Slug {get;set;}
    public string Description {get;set;}
    public User Owner {get;set;}
    public ICollection<CommunityGame> CommunityGames {get;set;}
    public ICollection<Player> Players {get;set;}
    public ICollection<CommunityUser> Users {get;set;}
    public DateTime InsertDate {get;set;}
}
