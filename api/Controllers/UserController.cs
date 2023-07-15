using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;
public class SignInViewModel {
    public string Id {get;set;}
    public string Email {get;set;}
}

[ApiController]
[Route("api/[controller]")]
public class UserController {
    
    private CommunityContext _context;
    public UserController(CommunityContext context) {
        this._context = context;
    }
    
    [HttpPost("DiscordSignIn")]
    public User? DiscordSignIn(SignInViewModel signInDetails){
        return _context.Users.FirstOrDefault(u => u.UserAuthMethods.Any(uam => uam.AuthMethod == AuthMethod.Discord && uam.AuthValue == signInDetails.Id));
    }
}