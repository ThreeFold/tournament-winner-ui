using System.Collections.Generic;

namespace TournamentWinner.Api.Models;
public class Community {
    public int Id {get;set; }
    public string Name {get;set;}
    public string? Slug {get;set;}
    public string Description {get;set;}
    public User Owner {get;set;}
    public IEnumerable<CommunityGame> Games {get;set;}
    public IEnumerable<Player> Players {get;set;}
    public IEnumerable<CommunityUser> Users {get;set;}
}

public class CommunityUser {
    public Community Community {get;set;}
    public User User {get;set;}
    public IEnumerable<CommunityUserRole> Roles {get;set;}
}

public class CommunityUserRole {
    public User User {get;set;}
    public CommunityRoleType RoleType {get;set;}
}
public enum CommunityRoleType {
    Administrator,
    Moderator,
    Manager,
    Member
}
public class User {
    public Guid Id {get;set;}
    public string? UsernamePrefix {get;set;}
    public string Username {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public DateTime PlayerCreationDate {get;set;}
    public IEnumerable<UserGame> Games {get;set;}
    public IEnumerable<UserHistory> History {get;set;}
}

public class UserHistory : User {
    public DateTime DateChanged {get;set;}
}

public class UserGame {
    public Game Game {get;set;}
    public User User {get;set;}
    public IEnumerable<UserGameCharacter> Characters {get;set;}
}

public class UserGameCharacter {
    public UserGame UserGame {get;set;}
    public Character Character {get;set;}
    public int Order {get;set;}
}
public class Player {
    public Game Game {get;set;}
    public string prefix {get;set;}
    public string Name {get;set;}
    public UserGame? User {get;set;}

}

public class Ranking {

}
public class CommunityGame {
    public Community Community {get;set;}
    public Game Game {get;set;}
    public IEnumerable<Ranking> Rankings {get;set;}
    public IEnumerable<League> Leagues {get;set;}
}
public class Game {

}
public class Character {

}
public class League {
    public int Id {get;set;}
    public string Name {get;set;}
}