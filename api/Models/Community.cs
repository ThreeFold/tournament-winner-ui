using Microsoft.AspNetCore.Identity;

namespace TournamentWinner.Api.Models;
public class Community {
    public int CommunityId {get;set; }
    public string Name {get;set;}
    public string? Slug {get;set;}
    public string Description {get;set;}
    public Guid OwnerUserId {get;set;}
    public User Owner {get;set;}
    public ICollection<CommunityGame> Games {get;set;}
    public ICollection<Player> Players {get;set;}
    public ICollection<CommunityUser> Users {get;set;}
    public DateTime InsertDate {get;set;}
}

public class CommunityUser {
    public int CommunityUserId {get;set;}
    public int CommunityId {get;set;}
    public Community Community {get;set;}
    public string UserId {get;set;}
    public User User {get;set;}
    public ICollection<CommunityUserRole> Roles {get;set;}
    public DateTime InsertDate {get;set;}
}

public class CommunityUserRole {
    public int CommunityUserRoleId {get;set;}
    public string UserId {get;set;}
    public User User {get;set;}
    public CommunityRoleType RoleType {get;set;}
    public DateTime InsertDate {get;set;}
}

public enum CommunityRoleType {
    Administrator,
    Moderator,
    Manager,
    Member
}

public class User : IdentityUser {
    public string? UsernamePrefix {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public DateTime PlayerCreationDate {get;set;}
    public ICollection<UserGame> Games {get;set;}
    public DateTime InsertDate {get;set;}
}

public class UserGame {
    public int UserGameId {get;set;}
    public int GameId {get;set;}
    public string UserId {get;set;}
    public Game Game {get;set;}
    public User User {get;set;}
    public ICollection<UserGameCharacter> Characters {get;set;}
    public DateTime InsertDate {get;set;}
}

public class UserGameCharacter {
    public int UserGameCharacterId {get;set;}
    public int UserGameId {get;set;}
    public int CharacterId {get;set;}
    public UserGame UserGame {get;set;}
    public Character Character {get;set;}
    public int Order {get;set;}
    public DateTime InsertDate {get;set;}
}

public class Player {
    public int PlayerId {get;set;}
    public int GameId {get;set;}
    public int UserGameId {get;set;}
    public string prefix {get;set;}
    public string Name {get;set;}
    public Game Game {get;set;}
    public UserGame? User {get;set;}
    public DateTime InsertDate {get;set;}

}

public class Ranking {
    public int RankingId {get;set;}
    public string Name {get;set;}
    public int CommunityGameId {get;set;}
    public DateTime PeriodStart {get;set;}
    public DateTime? PeriodEnd {get;set;}
    public DateTime InsertDate {get;set;}
    public ICollection<Rank> Ranks {get;set;}
    public CommunityGame CommunityGame {get;set;}
}
public class Rank {
    public int RankId {get;set;}
    public int PlayerId {get;set;}
    public Player Player {get;set;}
    public int RankValue {get;set;}
    public DateTime InsertDate {get;set;}
}

public class CommunityGame {
    public int CommunityGameId {get;set;}
    public int CommunityId {get;set;}
    public int GameId {get;set;}
    public Community Community {get;set;}
    public Game Game {get;set;}
    public ICollection<Ranking> Rankings {get;set;}
    public ICollection<League> Leagues {get;set;}
    public ICollection<Bracket> Brackets {get;set;}
    public DateTime InsertDate {get;set;}
}
public class Bracket {
    public int BracketId {get;set;}
    public ICollection<GameSet> Sets {get;set;}
    public DateTime InsertDate {get;set;}
}
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
public class Game {
    public int GameId {get;set;}
    public string Name {get;set;}
    public string Slug {get;set;}
    public string Description {get;set;}
    public ICollection<Character> Characters {get;set;}
    public DateTime ReleaseDate {get;set;}
    public DateTime InsertDate {get;set;}
}
public class CharacterGame {
    public int CharacterGameId {get;set;}
    public int CharacterId {get;set;}
    public int GameId {get;set;}    
    public string? UniqueIdentifier {get;set;}
    public Game Game {get;set;}
    public Character Character {get;set;}
}
public class Character {
    public int CharacterId {get;set;}
    public string Name {get;set;}
    public DateTime InsertDate {get;set;}
}

public class League {
    public int LeagueId {get;set;}
    public string Name {get;set;}
    public Uri? Homepage {get;set;}
    public string? Description {get;set;}
    public DateTime InsertDate {get;set;}
}