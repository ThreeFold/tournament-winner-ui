using Microsoft.AspNetCore.Mvc;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CommunityController : ControllerBase {

    public CommunityController() {

    }

    [HttpGet]
    public Community GetCommunity(string communityId){
        return new Community();
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