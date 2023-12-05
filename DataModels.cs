// Models Project

// Entities
public class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Initials { get; set; }
    public decimal Budget { get; set; }
    public int PrimaryKitColorId { get; set; }
    public int SecondaryKitColorId { get; set; }
    public int TownId { get; set; }

    // Navigation properties
    public Color PrimaryKitColor { get; set; }
    public Color SecondaryKitColor { get; set; }
    public Town Town { get; set; }
    public ICollection<Player> Players { get; set; }
    public ICollection<Game> HomeGames { get; set; }
    public ICollection<Game> AwayGames { get; set; }
}

public class Color
{
    public int ColorId { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Team> PrimaryKitTeams { get; set; }
    public ICollection<Team> SecondaryKitTeams { get; set; }
}

public class Town
{
    public int TownId { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public Country Country { get; set; }
    public ICollection<Team> Teams { get; set; }
}

public class Country
{
    public int CountryId { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Town> Towns { get; set; }
}

public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; }
    public int SquadNumber { get; set; }
    public int TeamId { get; set; }
    public int PositionId { get; set; }
    public bool IsInjured { get; set; }

    // Navigation properties
    public Team Team { get; set; }
    public Position Position { get; set; }
    public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
}

public class Position
{
    public int PositionId { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Player> Players { get; set; }
}

public class PlayerStatistic
{
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public int ScoredGoals { get; set; }
    public int Assists { get; set; }
    public int MinutesPlayed { get; set; }

    // Navigation properties
    public Game Game { get; set; }
    public Player Player { get; set; }
}

public class Game
{
    public int GameId { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }
    public DateTime DateTime { get; set; }
    public decimal HomeTeamBetRate { get; set; }
    public decimal AwayTeamBetRate { get; set; }
    public decimal DrawBetRate { get; set; }
    public string Result { get; set; }

    // Navigation properties
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    public ICollection<Bet> Bets { get; set; }
}

public class Bet
{
    public int BetId { get; set; }
    public decimal Amount { get; set; }
    public string Prediction { get; set; }
    public DateTime DateTime { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Game Game { get; set; }
}

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }

    // Navigation properties
    public ICollection<Bet> Bets { get; set; }
}
