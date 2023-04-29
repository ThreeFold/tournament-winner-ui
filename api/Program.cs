using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Data;
using TournamentWinner.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommunityContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommunityContextNpgsql")));
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentityServer()
    .AddApiAuthorization<User, ApplicationDbContext>();
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();
// builder.Services.dAuthentication(options => {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// });
    // .AddJwtBearer(options => {
    //     options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    //     options.Audience = builder.Configuration["Auth0:Audience"];
    // });

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
app.UseAuthorization();

app.Run();
