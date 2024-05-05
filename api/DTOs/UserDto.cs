using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.DTOs;

public class UserDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public ProfileDto? Profile { get; set; }
    public DateTime UserCreationDate { get; set; }
    public IEnumerable<(CommunityDto, PlayerDto)> Communities { get; set; } = new List<(CommunityDto Community, PlayerDto Player)>();
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
}

public class CommunityGameDto
{

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
}


