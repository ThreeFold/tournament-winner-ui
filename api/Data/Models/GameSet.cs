namespace TournamentWinner.Api.Models;

public class GameSet {
    public int GameSetId {get;set;}
    public int BracketId {get;set;}
    public int Player1Id {get;set;}
    public int Player1CharacterId {get;set;}
    public int Player2Id{get;set;}
    public int Player2CharacterId {get;set;}
    public Bracket Bracket {get;set;}
    public Player Player1 {get;set;}
    public Character? Player1Character {get;set;}
    public Player Player2 {get;set;}
    public Character? Player2Character {get;set;}
    public DateTime InsertDate {get;set;}
}
