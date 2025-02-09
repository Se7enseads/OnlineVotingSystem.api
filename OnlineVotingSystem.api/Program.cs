using OnlineVotingSystem.api.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("OnlineVotingSystem");
builder.Services.AddSqlite<OnlineVotingSystemContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.MigrateDbAsync();

app.Run();