// Data Project

// DbContext
public class FootballBookmakerDbContext : DbContext
{
    public FootballBookmakerDbContext(DbContextOptions<FootballBookmakerDbContext> options) : base(options) { }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Bet> Bets { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints here

        // Team
        modelBuilder.Entity<Team>()
            .HasOne(t => t.PrimaryKitColor)
            .WithMany(c => c.PrimaryKitTeams)
            .HasForeignKey(t => t.PrimaryKitColorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasOne(t => t.SecondaryKitColor)
            .WithMany(c => c.SecondaryKitTeams)
            .HasForeignKey(t => t.SecondaryKitColorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasOne(t => t.Town)
            .WithMany(town => town.Teams)
            .HasForeignKey(t => t.TownId)
            .OnDelete(DeleteBehavior.Restrict);

        // Town
        modelBuilder.Entity<Town>()
            .HasOne(t => t.Country)
            .WithMany(c => c.Towns)
            .HasForeignKey(t => t.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Player
        modelBuilder.Entity<Player>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Player>()
            .HasOne(p => p.Position)
            .WithMany(pos => pos.Players)
            .HasForeignKey(p => p.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        // PlayerStatistic
        modelBuilder.Entity<PlayerStatistic>()
            .HasKey(ps => new { ps.GameId, ps.PlayerId });

        modelBuilder.Entity<PlayerStatistic>()
            .HasOne(ps => ps.Game)
            .WithMany(g => g.PlayerStatistics)
            .HasForeignKey(ps => ps.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PlayerStatistic>()
            .HasOne(ps => ps.Player)
            .WithMany(p => p.PlayerStatistics)
            .HasForeignKey(ps => ps.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Game
        modelBuilder.Entity<Game>()
            .HasOne(g => g.HomeTeam)
            .WithMany(t => t.HomeGames)
            .HasForeignKey(g => g.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.AwayTeam)
            .WithMany(t => t.AwayGames)
            .HasForeignKey(g => g.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        // Bet
        modelBuilder.Entity<Bet>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bets)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bet>()
            .HasOne(b => b.Game)
            .WithMany(g => g.Bets)
            .HasForeignKey(b => b.GameId)
            .OnDelete(DeleteBehavior.Restrict);

        // Add any additional configurations as needed

        base.OnModelCreating(modelBuilder);
    }
}
