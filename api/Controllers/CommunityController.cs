using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class CommunityController : ControllerBase {

    private CommunityContext _context;
    public CommunityController(CommunityContext context) {
        this._context = context;
    }

    [HttpGet("list")]
    public IEnumerable<Community>? GetCommunities(int p = 1, int r = 20){
        return this._context.Communities.Take(r).Skip(p - 1 * r);
    }

    [HttpGet("{communityId}")]
    public Community? Get(string communityId){
        //communityId can be the slag or actual id, resolve to one
        if(int.TryParse(communityId, out var communityActualId)){
            return this._context.Communities.FirstOrDefault(c => c.CommunityId == communityActualId);
        }
        
        return this._context.Communities.FirstOrDefault(c => c.Slug == communityId);
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
    public Community Post(Community community){
        return new Community();
    }
    [HttpPatch]
    public void Patch(Community community){

    }
    [HttpDelete]
    public void Delete(Community community){

    }
}