using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.DTOs;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Services;

public interface IUserService
{
    public Task<UserDto?> RegisterUser(UserRegisterDto userToRegister);
    public Task<UserDto?> GetUser(string authProviderId, string authValue);
}
public class UserService : IUserService
{

    private CommunityContext context;
    public UserService(CommunityContext context)
    {
        this.context = context;
    }
    public async Task<UserDto?> RegisterUser(UserRegisterDto userToRegister)
    {
        var existingUser = await context.Users.Include(u => u.UserAuthMethods)
            .Include(u => u.Profile)
            .SingleOrDefaultAsync(u => u.Email == userToRegister.Email);

        if (existingUser != null)
        {
            var existingAuthMethod = existingUser.UserAuthMethods.SingleOrDefault(uam => uam.AuthProviderId == userToRegister.AuthProviderId);
            if (existingAuthMethod?.AuthValue != userToRegister.AuthProviderValue)
            {
                throw new ArgumentException("Could not find User for provided auth value");
            }
        }

        var user = new User()
        {
            Email = userToRegister.Email,
            UserCreationDate = DateTime.UtcNow,
            UserAuthMethods = new List<UserAuthMethod>(){
                new UserAuthMethod(){
                    AuthProviderId = userToRegister.AuthProviderId,
                    AuthValue = userToRegister.AuthProviderValue
                }
            },
            Profile = new Profile()
            {
                Handle = userToRegister.Username,
            }
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        var userDto = UserDto.GetDto(user);
        return userDto;
    }

    public async Task<UserDto?> GetUser(string authProviderId, string authValue)
    {
        var user = await context.Users
            .Include(u => u.Profile)
            .FirstOrDefaultAsync(u => u.UserAuthMethods.Any(uam => uam.AuthProviderId == authProviderId && uam.AuthValue == authValue));

        return UserDto.GetDto(user);
    }
}

