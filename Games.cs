// Client Project

public class FootballBookmakerService
{
    private readonly FootballBookmakerDbContext _dbContext;

    public FootballBookmakerService(FootballBookmakerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Team CRUD operations
    public List<Team> GetAllTeams()
    {
        return _dbContext.Teams.ToList();
    }

    public Team GetTeamById(int teamId)
    {
        return _dbContext.Teams.Find(teamId);
    }

    public void AddTeam(Team team)
    {
        _dbContext.Teams.Add(team);
        _dbContext.SaveChanges();
    }

    public void UpdateTeam(Team team)
    {
        _dbContext.Teams.Update(team);
        _dbContext.SaveChanges();
    }

    public void DeleteTeam(int teamId)
    {
        var team = _dbContext.Teams.Find(teamId);
        if (team != null)
        {
            _dbContext.Teams.Remove(team);
            _dbContext.SaveChanges();
        }
    }

    // Game CRUD operations
    public List<Game> GetAllGames()
    {
        return _dbContext.Games.ToList();
    }

    public Game GetGameById(int gameId)
    {
        return _dbContext.Games.Find(gameId);
    }

    public void AddGame(Game game)
    {
        _dbContext.Games.Add(game);
        _dbContext.SaveChanges();
    }

    public void UpdateGame(Game game)
    {
        _dbContext.Games.Update(game);
        _dbContext.SaveChanges();
    }

    public void DeleteGame(int gameId)
    {
        var game = _dbContext.Games.Find(gameId);
        if (game != null)
        {
            _dbContext.Games.Remove(game);
            _dbContext.SaveChanges();
        }
    }

    // User CRUD operations
    public List<User> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    public User GetUserById(int userId)
    {
        return _dbContext.Users.Find(userId);
    }

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _dbContext.Users.Find(userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }

    // Add more methods based on your application's requirements
}
