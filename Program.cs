using FluentValidation;
using IverMiniApi.DB;
using IverMiniApi.Models;
using IverMiniApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//Service registration starts here
var config = builder.Configuration;
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true


    };
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbConnectionFactory, MsSqlDbConnectionFactory>(sp => new MsSqlDbConnectionFactory(config["ConnectionStrings:IverBirdDb"]!));
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IIverBirdLeaderboardService, IverBirdLeaderboardService>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


//Service registration ends here
var app = builder.Build();
//Middleware registration and Configuration starts here
app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthentication();
app.UseAuthorization();

app.MapPost("leaderboard", [Authorize] async (IIverBirdLeaderboardService service, IverBirdLeaderboard playerAndScore,
    IValidator<IverBirdLeaderboard> validator) =>
{
    var validationResult = await validator.ValidateAsync(playerAndScore);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult.Errors);
    }

    var created = await service.AddScoreAsync(playerAndScore);
    if (!created)
    {
        return Results.BadRequest();
    }
    return Results.Created($"/api/leaderboard/{playerAndScore.Name}", playerAndScore);
});

app.MapGet("leaderboard", [Authorize] async (IIverBirdLeaderboardService service) =>
{
    var leaderboard = await service.GetLeaderboardAsync();
    return Results.Ok(leaderboard);
});

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();
//Middleware registration and Configuration ends here
app.Run();
