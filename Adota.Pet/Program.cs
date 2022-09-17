using Adota.Pet.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add DB
builder.Services.AddDbContext<PetContext>(opts => {
    opts.EnableSensitiveDataLogging();
    opts.EnableDetailedErrors();
    opts.UseNpgsql(configuration.GetConnectionString("AppDb"));
}, ServiceLifetime.Transient);

var app = builder.Build();




// Pet Controller
app.MapGet("pets", async ([FromQuery] string? nome, [FromServices] PetContext db) =>
{
    if(nome == null) Results.BadRequest();
    var result = await db.Pet.Where(pet => pet.Name.Contains(nome)).ToListAsync();
    return Results.Ok(result);
});

app.Run();
