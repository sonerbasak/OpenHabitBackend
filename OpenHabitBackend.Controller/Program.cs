using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using OpenHabitBackend.Business.Abstract;
using OpenHabitBackend.Business.Concrete;
using OpenHabitBackend.Data.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HabitDbContext>(options =>
    options.UseInMemoryDatabase("OpenHabitDb"));

builder.Services.AddControllers();

builder.Services.AddScoped<IHabitService, HabitManager>();
builder.Services.AddScoped<IUserService, UserManager>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();