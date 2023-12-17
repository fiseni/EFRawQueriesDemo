using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFRawQueriesDemo.Options;

public class FromSqlInterpolated
{
    public static async Task RunAsync()
    {
        await WithSimpleParameter();
        await WithSqlParameter();
    }

    public static async Task WithSimpleParameter()
    {
        using var dbContext = new TestDbContext();

        var id = 1;

        var result = await dbContext.Movies
            .FromSqlInterpolated($"Select * from Movies where Id = {id}")
            .ToListAsync();

        result = await dbContext.Movies
            .FromSqlInterpolated($"GetMoviesById {id}")
            .ToListAsync();

        int? voteCount = null;

        result = await dbContext.Movies
            .FromSqlInterpolated($"Select * from Movies where VoteCount = {voteCount}")
            .ToListAsync();

        result = await dbContext.Movies
            .FromSqlInterpolated($"GetMoviesByVoteCount {voteCount}")
            .ToListAsync();

        var p0 = 1;
        var p1 = "Overview1";
        var p2 = 3;

        result = await dbContext.Movies
            .FromSqlInterpolated($"GetMovies {p0}, {p1}, {p2}")
            .ToListAsync();
    }

    public static async Task WithSqlParameter()
    {
        using var dbContext = new TestDbContext();

        var id = new SqlParameter("Id", 1);

        var result = await dbContext.Movies
            .FromSqlInterpolated($"Select * from Movies where Id = {id}")
            .ToListAsync();

        result = await dbContext.Movies
            .FromSqlInterpolated($"GetMoviesById {id}")
            .ToListAsync();

        var voteCount = new SqlParameter("VoteCount", DBNull.Value);

        result = await dbContext.Movies
            .FromSqlInterpolated($"Select * from Movies where VoteCount = {voteCount}")
            .ToListAsync();

        result = await dbContext.Movies
            .FromSqlInterpolated($"GetMoviesByVoteCount {voteCount}")
            .ToListAsync();

        var p0 = new SqlParameter("Id", 1);
        var p1 = new SqlParameter("Overview", "Overview1");
        var p2 = new SqlParameter("VoteCount", 3);

        result = await dbContext.Movies
            .FromSqlInterpolated($"GetMovies {p0}, {p1}, {p2}")
            .ToListAsync();
    }

    public class TestDbContext : BaseDbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
    }
}
