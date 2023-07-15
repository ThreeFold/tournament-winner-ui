using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;
public class SignInViewModel {
    public string Id {get;set;}
    public string Email {get;set;}
}

public class UserCreateViewModel {

    public string Username {get;set;}
    public string Email {get;set;}
    public AuthMethod AuthMethod {get;set;}
    public string AuthMethodValue{get;set;}
}

[ApiController]
[Route("api/[controller]")]
public class UserController {
    
    private CommunityContext _context;
    public UserController(CommunityContext context) {
        this._context = context;
    }
    
    [HttpPost("DiscordSignIn")]
    public ActionResult<User> DiscordSignIn(SignInViewModel signInDetails){
        var user = _context.Users.FirstOrDefault(u => u.UserAuthMethods.Any(uam => uam.AuthMethod == AuthMethod.Discord && uam.AuthValue == signInDetails.Id));
        if(user == null){
            return new StatusCodeResult(StatusCodes.Status404NotFound);
        }
        return user;
    }
    
    [HttpPost("register")]
    public async Task<User?> CreateAccount(UserCreateViewModel userToCreate){
        var user = new User(){
            Email = userToCreate.Email,
            UserCreationDate = DateTime.Now,
            UserAuthMethods = new List<UserAuthMethod>(){
                new UserAuthMethod(){
                    AuthMethod = userToCreate.AuthMethod,
                    AuthValue = userToCreate.AuthMethodValue
                }
            }
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}