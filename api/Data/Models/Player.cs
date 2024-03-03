namespace TournamentWinner.Api.Models;

public class Player {
    public int Id {get;set;}
    public string? Prefix {get;set;}
    public string? Name {get;set;}
    public ICollection<CommunityGamePlayer> CommunityGamePlayer {get;set;}
    public DateTime InsertDate {get;set;}

}

public class CommunityGamePlayer {
    public int Id {get;set;}
    public int PlayerId {get;set;}
    public int CommunityGameId {get;set;}


    public CommunityGame CommunityGame {get;set;}
    public Player Player {get;set;}

    ///<summary>
    /// Represents the User of the Player so that they can manage 
    /// and consolidate multiple players across communities
    ///</summary>
    public User? User {get;set;}
}
