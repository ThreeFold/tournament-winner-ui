namespace TournamentWinner.Api.Models;

public class Profile {
    public string ProfileId {get;set;}
    public string? Prefix {get;set;}
    public string? Handle {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public string ProfileImage {get;set;}
    public string? UserId {get;set;}
    public User User {get;set;}
    public ICollection<ProfileGame> Games {get;set;}
    public DateTime InsertDate {get;set;}
}