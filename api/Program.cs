using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommunityContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommunityContextNpgsql")));
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CommunityContext>();
builder.Services.AddIdentityServer()
    .AddApiAuthorization<User, CommunityContext>();
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
