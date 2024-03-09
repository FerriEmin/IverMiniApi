using IverMiniApi.DB;
using IverMiniApi.Models;
using IverMiniApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Service registration starts here
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("IverBirdLeaderboard");
});
builder.Services.AddScoped<IIverBirdLeaderboardService, IverBirdLeaderboardService>();
builder.Services.AddScoped<IverBirdLeaderboard>();



//Service registration ends here
var app = builder.Build();
//Middleware registration and Configuration starts here
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/leaderboard", async (DataContext context) =>
{
    var leaderboardService = new IverBirdLeaderboardService(context);
    return await leaderboardService.GetAllPlayerScoresAsync();
});


//Middleware registration and Configuration ends here
app.Run();
