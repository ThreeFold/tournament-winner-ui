namespace TournamentWinner.Api.Models;

public class UserAuthMethod {
    public string UserAuthMethodId {get;set;}
    public string UserId {get;set;}
    public string AuthValue {get;set;}
    public AuthMethod AuthMethod {get;set;}
    public User User {get;set;}
}
