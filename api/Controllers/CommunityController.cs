using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunityController : ControllerBase {

    private CommunityContext _context;
    public CommunityController(CommunityContext context) {
        this._context = context;
    }

    [HttpGet]
    public string Index(){
        return "success";
    }

    [HttpGet("list")]
    public IEnumerable<Community>? GetCommunities(int p = 1, int r = 20){
        var toSkip = (p - 1) * r;
        return this._context.Communities
        .Include(c => c.Owner)
        .Take(r)
        .Skip(toSkip)
        .OrderByDescending(c => c.InsertDate);
    }

    [HttpGet("{communityId}/games")]
    public async Task<IEnumerable<CommunityGame>?> GetGames(string communityId){
        IQueryable<CommunityGame> query;
        if(int.TryParse(communityId, out var communityActualId)){
            query = this._context.CommunityGames
                .Where(c => c.Community.CommunityId == communityActualId);
        }
        else {
            query = this._context.CommunityGames
            .Where(c => c.Community.Slug == communityId);
        }
        return query.Select(cg => 
            new CommunityGame{
                CommunityId = cg.CommunityId,
                GameId = cg.GameId,
                Community = new Community{
                    Description = cg.Community.Description,
                    CommunityId = cg.Community.CommunityId,
                    Name = cg.Community.Name,
                    Owner = new User {
                        UserId = cg.Community.Owner.UserId,
                    },
                    Slug = cg.Community.Slug,
                    InsertDate = cg.Community.InsertDate,
                },
                CommunityGameId = cg.CommunityGameId,
                Game = new Game{
                    BannerImage = cg.Game.BannerImage,
                    Description = cg.Game.Description,
                    GameId = cg.Game.GameId,
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

        if(game == null)
        {
            return NotFound("Game not found");
        }
        if(community == null)
        {
            return NotFound("Community not found");
        }

        var communityGame = await this._context.CommunityGames.FirstOrDefaultAsync(cg => cg.CommunityId == community.CommunityId && cg.GameId == game.GameId);

        if(communityGame == null){
            return NotFound("Community does not play this game");
        }
        return Ok(new CommunityGame(){
            GameId = game.GameId,
            Game = new Game()
        });
    }

    private async Task<Community?> GetCommunity(string communityId){
        if(int.TryParse(communityId, out var communityActualId)){
            return await this._context.Communities.FirstOrDefaultAsync(c => c.CommunityId == communityActualId);
        }
        return await this._context.Communities.FirstOrDefaultAsync(c => c.Slug == communityId);

    }

    private async Task<Game?> GetGame(string gameId){
        if(int.TryParse(gameId, out var gameActualId)){
            return await this._context.Games.FirstOrDefaultAsync(g => g.GameId == gameActualId);
        }
        return await this._context.Games.FirstOrDefaultAsync(g => g.Slug == gameId);
    }

    [HttpGet("{communityId}")]
    public Task<Community?> Get(string communityId){
        //communityId can be the slug or actual id, resolve to one
        if(int.TryParse(communityId, out var communityActualId)){
            return this._context.Communities.FirstOrDefaultAsync(c => c.CommunityId == communityActualId);
        }
        
        return this._context.Communities.FirstOrDefaultAsync(c => c.Slug == communityId);
    }

    [HttpGet("{communityId}/players")]
    public IEnumerable<Player> GetPlayers(string communityId){
        //communityId can be the slag or actual id, resolve to one
        if(int.TryParse(communityId, out var communityActualId)){
            return this._context.Communities.FirstOrDefault(c => c.CommunityId == communityActualId)?.Players ?? new List<Player>();
        }
        
        return this._context.Communities.FirstOrDefault(c => c.Slug == communityId)?.Players ?? new List<Player>();
    }

    [HttpPost]
    public async Task<Community> CreateCommunity(Community community){
        Console.Out.WriteLine($"Incoming Request {community}");
        await this._context.Communities.AddAsync(community);
        await this._context.SaveChangesAsync();
        return community;
    }

    [HttpPatch]
    public void Patch(Community community){

    }
    [HttpDelete]
    public void Delete(Community community){

    }
}
