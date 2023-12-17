using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFRawQueriesDemo.Options;

public class SqlQueryRaw
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

        var result = await dbContext.Database
            .SqlQueryRaw<Movie>("Select * from Movies where Id = {0}", id)
            .ToListAsync();

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMoviesById {0}", id)
            .ToListAsync();

        int? voteCount = null;

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("Select * from Movies where VoteCount = {0}", voteCount)
            .ToListAsync();

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMoviesByVoteCount {0}", voteCount)
            .ToListAsync();

        var p0 = 1;
        var p1 = "Overview1";
        var p2 = 3;

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMovies {0}, {1}, {2}", p0, p1, p2)
            .ToListAsync();
    }

    public static async Task WithSqlParameter()
    {
        using var dbContext = new TestDbContext();

        var id = new SqlParameter("Id", 1);

        var result = await dbContext.Database
            .SqlQueryRaw<Movie>("Select * from Movies where Id = {0}", id)
            .ToListAsync();

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMoviesById {0}", id)
            .ToListAsync();

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("Select * from Movies where Id = @id", id)
            .ToListAsync();

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMoviesById @id", id)
            .ToListAsync();

        var voteCount = new SqlParameter("VoteCount", DBNull.Value);

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("Select * from Movies where VoteCount = {0}", voteCount)
            .ToListAsync();

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMoviesByVoteCount {0}", voteCount)
            .ToListAsync();

        var p0 = new SqlParameter("Id", 1);
        var p1 = new SqlParameter("Overview", "Overview1");
        var p2 = new SqlParameter("VoteCount", 3);

        result = await dbContext.Database
            .SqlQueryRaw<Movie>("GetMovies {0}, {1}, {2}", p0, p1, p2)
            .ToListAsync();
    }


    public class TestDbContext : BaseDbContext
    {
    }
}
