using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.DTOs;

public class UserDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public ProfileDto? Profile { get; set; }
    public DateTime UserCreationDate { get; set; }
    public IEnumerable<(CommunityDto, PlayerDto)> Communities { get; set; } = new List<(CommunityDto Community, PlayerDto Player)>();

    public static UserDto? GetDto(User? user)
    {
        if(user == null)
            return null;
        return new UserDto
        {
            Email = user.Email,
            Id = user.Id,
            UserCreationDate = user.UserCreationDate,
            Profile = ProfileDto.GetDto(user.Profile),
        };
    }

}

public class ProfileDto
{
    public string? Prefix { get; set; }
    public string? Handle { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Bio { get; set; }
    public string? ProfileImage { get; set; }
    public string? UserId { get; set; }
    public DateTime InsertDate { get; set; }

    public static ProfileDto? GetDto(Profile? profile)
    {
        if (profile == null)
            return null;

        return new ProfileDto
        {
            Handle = profile?.Handle,
            Prefix = profile?.Prefix,
            FirstName = profile?.FirstName,
            LastName = profile?.LastName,
            Bio = profile?.Bio,
            ProfileImage = profile?.ProfileImage,
            UserId = profile?.UserId,
        };
    }
}

public class PlayerDto
{
    public CommunityRoleType Role { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public string? Prefix { get; set; }
    public required string Handle { get; set; }
}

public class CommunityGamePlayerDto
{
    public required string PlayerId { get; set; }
    public required Player Player { get; set; }
    public double Rank { get; } = 0.0f;

    public static CommunityGamePlayerDto GetDto(CommunityGamePlayer player) {
        throw new NotImplementedException();
    }
}

public class CommunityGameDto
{

    public int Id { get; set; }
    public int CommunityId {get;set;}
    public int GameId {get;set;}
    public CommunityDto? Community { get; set; }
    public GameDto? Game { get; set; }
    public required IEnumerable<CommunityGamePlayerDto?> Players { get; set; } = new List<CommunityGamePlayerDto?>();
    public DateTime DateAdded { get; set; }

    public static CommunityGameDto? GetDto(CommunityGame? communityGame) {
        if(communityGame == null)
            return null;
        return new CommunityGameDto() {
            GameId = communityGame.GameId,
            CommunityId = communityGame.CommunityId,
            Game = GameDto.GetDto(communityGame.Game),
            Community = CommunityDto.GetDto(communityGame.Community),
            Players = communityGame.CommunityGamePlayers.Select(x => CommunityGamePlayerDto.GetDto(x)),
            Id = communityGame.Id,
            DateAdded = communityGame.InsertDate,
        };

    }
}

public class GameDto {
    
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public required string Description { get; set; }
    public required string BannerImage { get; set; }
    public required string IconImage { get; set; }
    public IEnumerable<CharacterGameDto> CharacterGames { get; set; } = new List<CharacterGameDto>();
    public IEnumerable<CommunityGameDto> CommunityGames { get; set; } = new List<CommunityGameDto>();
    public DateTime ReleaseDate { get; set; }

    public static GameDto GetDto(Game game) {
        throw new NotImplementedException();
    }
}

public class CharacterGameDto {

}

public class CommunityDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Slug { get; set; }
    public required string Description { get; set; }
    public required string Country { get; set; }
    public required string RegionState { get; set; }
    public string? City { get; set; }
    public IEnumerable<CommunityGameDto> CommunityGames { get; set; } = new List<CommunityGameDto>();
    public IDictionary<CommunityRoleType, IEnumerable<PlayerDto>> Players { get; set; } = new Dictionary<CommunityRoleType, IEnumerable<PlayerDto>>();

    public static CommunityDto? GetDto(Community? community) {
        throw new NotImplementedException();
    }
}


