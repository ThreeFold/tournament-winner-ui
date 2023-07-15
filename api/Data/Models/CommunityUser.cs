namespace TournamentWinner.Api.Models;

public class CommunityUser {
    public int CommunityUserId {get;set;}
    public int CommunityId {get;set;}
    public Community Community {get;set;}
    public string UserId {get;set;}
    public User User {get;set;}
    public ICollection<CommunityUserRole> Roles {get;set;}
    public DateTime InsertDate {get;set;}
}
