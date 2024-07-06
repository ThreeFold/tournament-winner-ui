using Microsoft.EntityFrameworkCore;

namespace TournamentWinner.Api.Models;
public class Community
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public string RegionState { get; set; }
    public string? City { get; set; }
    public Color ThemeColor { get; set; } 
    public ICollection<CommunityGame> CommunityGames { get; set; }
    public ICollection<CommunityUser> Users { get; set; }
    public ICollection<SocialLink> SocialLinks { get; set; }
    public DateTime InsertDate { get; set; }
}

[Owned]
public class SocialLink {
    public string Name { get; set; }
    public string Url { get; set; }
}

[Owned]
public class Color {
    public byte Red {get;set;}
    public byte Green {get;set;}
    public byte Blue {get;set;}
    public float Opacity {get;set;}
}
