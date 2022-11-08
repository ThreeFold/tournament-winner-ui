using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CommunityController : ControllerBase {

    private CommunityContext _context;
    public CommunityController(CommunityContext context) {
        this._context = context;
    }

    [HttpGet]
    public Community? GetCommunity(string communityId){
        //communityId can be the slag or actual id, resolve to one

        if(int.TryParse(communityId, out var communityActualId)){
            return this._context.Communities.FirstOrDefault(c => c.CommunityId == communityActualId);
        }
        
        return this._context.Communities.FirstOrDefault(c => c.Slug == communityId);
    }
    [HttpPost]
    public Community CreateCommunity(Community community){
        return new Community();
    }
    [HttpPatch]
    public void UpdateCommunity(Community community){

    }
    [HttpDelete]
    public void DeleteCommunity(Community community){

    }
}