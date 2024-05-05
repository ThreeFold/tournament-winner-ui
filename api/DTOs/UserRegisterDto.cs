namespace TournamentWinner.Api.DTOs;

public class UserRegisterDto {
    public string Email { get; set; }
    public string Username { get; set; }
    public string AuthProviderId { get; set; }
    public string AuthProviderValue { get; set; } 
}

