using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Messenger.Application.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    private string _connectionString { get; }

    public AppDbContext(string connectionString) 
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);

        var databaseCreator = Database.GetService<IDatabaseCreator>() as IRelationalDatabaseCreator;

        if (databaseCreator == null) return;
        if (!databaseCreator.CanConnect()) databaseCreator.Create();
        if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        Database.GetAppliedMigrations();
    }
}