using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommunityContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommunityContextNpgsql")));
// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     }).AddJwtBearer(options =>
//     {
//         options.Authority = "https://dev-80ja08wntnvjbfkt.us.auth0.com/";
//         options.Audience = "http://tournament-winner/api";
//     });

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Community}/{action=Index}/{id?}");
// app.UseAuthentication();

app.Run();
