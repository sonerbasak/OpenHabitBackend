using Microsoft.EntityFrameworkCore;
using OpenHabitBackend.Business.Abstract;
using OpenHabitBackend.Business.Concrete;
using OpenHabitBackend.Data.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HabitDbContext>(options =>
    options.UseInMemoryDatabase("OpenHabitDb"));

builder.Services.AddControllers();

builder.Services.AddScoped<IHabitService, HabitManager>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.MapControllers();
app.Run();