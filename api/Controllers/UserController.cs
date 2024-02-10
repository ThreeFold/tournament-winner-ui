using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;
public class SignInViewModel {
    public string AuthProviderId {get;set;}
    public string AuthValue {get;set;}
}

public class UserCreateViewModel {

    public string Username {get;set;}
    public string Email {get;set;}
    public string AuthProviderId {get;set;}
    public string AuthValue {get;set;}
}

[ApiController]
[Route("api/[controller]")]
public class UserController {
    
    private CommunityContext _context;
    public UserController(CommunityContext context) {
        this._context = context;
    }
    
    [HttpPost("signin")]
    public ActionResult<User?> SignIn(SignInViewModel signInViewModel) {
        var user = _context.Users.FirstOrDefault(u => u.UserAuthMethods.Any(uam => uam.AuthProviderId == signInViewModel.AuthProviderId && uam.AuthValue == signInViewModel.AuthValue));
        if(user == null)
            return new NotFoundResult();
        
        return new User(){
            Email = user.Email,
            UserCreationDate = user.UserCreationDate,
            Profile = new Profile {
                Handle = user.Profile?.Handle,
                
            }
        };
    }
    
    [HttpPost("register")]
    public async Task<User?> CreateAccount(UserCreateViewModel userToCreate){
        var user = new User(){
            Email = userToCreate.Email,
            UserCreationDate = DateTime.UtcNow,
            UserAuthMethods = new List<UserAuthMethod>(){
                new UserAuthMethod(){
                    AuthProviderId = userToCreate.AuthProviderId,
                    AuthValue = userToCreate.AuthValue
                }
            }
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
