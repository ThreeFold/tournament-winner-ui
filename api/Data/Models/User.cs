namespace TournamentWinner.Api.Models;

public class User  {
    public string UserId {get;set;}
    public string Email { get; set; }
    public Profile? Profile {get;set;}
    public DateTime UserCreationDate {get;set;}
    public ICollection<UserAuthMethod> UserAuthMethods {get;set;}
    public DateTime InsertDate {get;set;}
}
