using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Services;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommunityContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommunityContextNpgsql")));
builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = "https://dev-80ja08wntnvjbfkt.us.auth0.com/";
            options.Audience = "https://api.combo-king.com/";
        });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
var app = builder.Build();
app.Logger.LogInformation(builder.Configuration.GetConnectionString("CommunityContextNpgsql"));
var root = (IConfigurationRoot)builder.Configuration;
app.Logger.LogInformation(root.GetDebugView());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Community}/{action=Index}/{id?}");

app.Run();
