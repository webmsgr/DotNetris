using DotNetris.Network.Server.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetris.Network.Server.Database;

public class DotNetrisContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<DbReplay> Replays { get; set; }
    private string ConnectionString;

    public DotNetrisContext()
    {
        // for entity framework to be happy
        ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=DotNetris;Trusted_Connection=True";
    }
    
    public DotNetrisContext(string ConnectionString)
    {
        this.ConnectionString = ConnectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(DotNetrisContext).Assembly);
}