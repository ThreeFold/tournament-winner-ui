namespace TournamentWinner.Api.Models;

public class CommunityUserRole {
    public int CommunityUserRoleId {get;set;}
    public string UserId {get;set;}
    public User User {get;set;}
    public CommunityRoleType RoleType {get;set;}
    public DateTime InsertDate {get;set;}
}
