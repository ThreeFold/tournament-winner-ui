using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Services;
using TournamentWinner.Api.DTOs;
using TournamentWinner.Api.ViewModels;

namespace TournamentWinner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController {
    
    private IUserService _userService;

    public UserController(IUserService userService) {
        this._userService = userService;
    }
    
    [HttpPost("signin")]
    public async Task<ActionResult<UserViewModel?>> SignIn(SignInViewModel signInViewModel) {
        var dto = await this._userService.GetUser(signInViewModel.AuthProviderId, signInViewModel.AuthValue);
        if(dto == null)
            return new NotFoundResult();
        return this.GetUserViewModel(dto);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserViewModel?>> CreateAccount(UserCreateViewModel userToCreate){
        var dto = new UserRegisterDto();
        var registeredUser = await this._userService.RegisterUser(dto);
        if(registeredUser == null)
            return new BadRequestResult();

        return this.GetUserViewModel(registeredUser);
    }

    private UserViewModel GetUserViewModel(UserDto dto)
    {
        throw new NotImplementedException();
    }
}
