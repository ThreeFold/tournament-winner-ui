using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;

public class CreateCommunityRequestDto
{
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public string RegionState { get; set; }
    public string? City { get; set; }
    public string OwnerId { get; set; }
}
[ApiController]
[Route("api/[controller]")]
public class CommunityController : ControllerBase
{

    private CommunityContext _context;
    public CommunityController(CommunityContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public string Index()
    {
        return "success";
    }

    [HttpGet("list")]
    public IEnumerable<Community>? GetCommunities(int p = 1, int r = 20)
    {
        var toSkip = (p - 1) * r;
        return this._context.Communities
        .Include(c => c.Users.Where(u => u.Role == CommunityRoleType.Owner))
        .Take(r)
        .Skip(toSkip)
        .OrderByDescending(c => c.InsertDate);
    }

    [HttpGet("{communityId}/games")]
    public async Task<IEnumerable<CommunityGame>?> GetGames(string communityId)
    {
        IQueryable<CommunityGame> query;
        if (int.TryParse(communityId, out var communityActualId))
        {
            query = this._context.CommunityGames
                .Where(c => c.Community.Id == communityActualId);
        }
        else
        {
            query = this._context.CommunityGames
            .Where(c => c.Community.Slug == communityId);
        }
        return query.Select(cg =>
            new CommunityGame
            {
                CommunityId = cg.CommunityId,
                GameId = cg.GameId,
                Community = new Community
                {
                    Description = cg.Community.Description,
                    Id = cg.Community.Id,
                    Name = cg.Community.Name,
                    Slug = cg.Community.Slug,
                    InsertDate = cg.Community.InsertDate,
                },
                Id = cg.Id,
                Game = new Game
                {
                    BannerImage = cg.Game.BannerImage,
                    Description = cg.Game.Description,
                    Id = cg.Game.Id,
                    IconImage = cg.Game.IconImage,
                    Name = cg.Game.Name,
                    InsertDate = cg.Game.InsertDate,
                    ReleaseDate = cg.Game.ReleaseDate,
                    Slug = cg.Game.Slug,
                },
                InsertDate = cg.InsertDate,
            });
    }

    [HttpGet("{communityId}/game/{gameId}")]
    public async Task<IActionResult> GetGame(string communityId, string gameId)
    {
        Game? game = await GetGame(gameId);
        Community? community = await GetCommunity(communityId);

        if (game == null)
        {
            return NotFound("Game not found");
        }
        if (community == null)
        {
            return NotFound("Community not found");
        }

        var communityGame = await this._context.CommunityGames.FirstOrDefaultAsync(cg => cg.CommunityId == community.Id && cg.GameId == game.Id);

        if (communityGame == null)
        {
            return NotFound("Community does not play this game");
        }
        return Ok(new CommunityGame()
        {
            GameId = game.Id,
            Game = new Game()
        });
    }

    private async Task<Community?> GetCommunity(string communityId)
    {
        if (int.TryParse(communityId, out var communityActualId))
        {
            return await this._context.Communities.FirstOrDefaultAsync(c => c.Id == communityActualId);
        }
        return await this._context.Communities.FirstOrDefaultAsync(c => c.Slug == communityId);

    }

    private async Task<Game?> GetGame(string gameId)
    {
        if (int.TryParse(gameId, out var gameActualId))
        {
            return await this._context.Games.FirstOrDefaultAsync(g => g.Id == gameActualId);
        }
        return await this._context.Games.FirstOrDefaultAsync(g => g.Slug == gameId);
    }

    [HttpGet("{communityId}")]
    public Task<Community?> Get(string communityId)
    {
        //communityId can be the slug or actual id, resolve to one
        if (int.TryParse(communityId, out var communityActualId))
        {
            return this._context.Communities.FirstOrDefaultAsync(c => c.Id == communityActualId);
        }

        return this._context.Communities.FirstOrDefaultAsync(c => c.Slug == communityId);
    }

    [HttpGet("{communityId}/players")]
    public IEnumerable<Player> GetPlayers(string communityId)
    {
        //communityId can be the slag or actual id, resolve to one
        if (int.TryParse(communityId, out var communityActualId))
        {
            return this._context.Communities
                .FirstOrDefault(c => c.Id == communityActualId)?.CommunityGames.SelectMany(cg => cg.CommunityGamePlayers.Select(cgp => cgp.Player))
                ?? new List<Player>();
        }

        return this._context.Communities
            .FirstOrDefault(c => c.Slug == communityId)?.CommunityGames.SelectMany(cg => cg.CommunityGamePlayers.Select(cgp => cgp.Player))
            ?? new List<Player>();

    }

    [HttpPost]
    public async Task<Community?> CreateCommunity(CreateCommunityRequestDto dto)
    {
        if (!this.ModelState.IsValid)
        {
            this.HttpContext.Response.StatusCode = 422;
            return null;
        }
        var community = new Community()
        {
            City = dto.City,
            Name = dto.Name,
            Slug = dto.Slug,
            Users = new List<CommunityUser>(){
                new CommunityUser(){
                    Role = CommunityRoleType.Owner,
                    UserId = dto.OwnerId,
                }
            },
            Country = dto.Country,
            Description = dto.Description,
            RegionState = dto.RegionState,
        };
        await this._context.AddAsync(community);
        await this._context.SaveChangesAsync();
        return community;
    }

    [HttpPatch]
    public void Patch(Community community)
    {

    }
    [HttpDelete]
    public void Delete(Community community)
    {

    }
}
