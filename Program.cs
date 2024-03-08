using IverMiniApi.DB;
using IverMiniApi.Models;
using IverMiniApi.Services;

var builder = WebApplication.CreateBuilder(args);
//Service registration starts here
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbConnectionFactory, MsSqlDbConnectionFactory>(sp => new MsSqlDbConnectionFactory(builder.Configuration.GetValue<string>("ConnectionStrings:IverBirdDb")));

builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddSingleton<IIverBirdLeaderboardService, IverBirdLeaderboardService>();



//Service registration ends here
var app = builder.Build();
//Middleware registration and Configuration starts here
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("leaderboard", async (IIverBirdLeaderboardService service, IverBirdLeaderboard playerAndScore) =>
{
    var created = await service.AddScoreAsync(playerAndScore);
    if (!created)
    {
        return Results.BadRequest();
    }
    return Results.Created($"/api/leaderboard/{playerAndScore.Name}", playerAndScore);
});

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();
//Middleware registration and Configuration ends here
app.Run();
