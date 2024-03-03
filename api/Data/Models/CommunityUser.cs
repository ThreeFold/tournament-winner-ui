namespace TournamentWinner.Api.Models;

public class CommunityUser {
    public int Id {get;set;}
    public int CommunityId {get;set;}
    public Community Community {get;set;}
    public string UserId {get;set;}
    public User User {get;set;}
    public CommunityRoleType Role {get;set;}
    public DateTime InsertDate {get;set;}
}
