using EFRawQueriesDemo.Options;

await FromSql.RunAsync();
await FromSqlInterpolated.RunAsync();
await FromSqlRaw.RunAsync();
await SqlQuery.RunAsync();
await SqlQueryRaw.RunAsync();
await Execute.RunAsync();
await ExecuteRaw.RunAsync();

Console.WriteLine();
