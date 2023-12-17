using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFRawQueriesDemo;

public class BaseDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=EFRawQueriesDemo;Integrated Security=SSPI;Trusted_Connection=True;";

        optionsBuilder.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}
