using IverMiniApi.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Service registration starts here

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IverBirdDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IverBirdDb")));



//Service registration ends here
var app = builder.Build();
//Middleware registration and Configuration starts here

app.UseSwagger();
app.UseSwaggerUI();






//Middleware registration and Configuration ends here
app.Run();
