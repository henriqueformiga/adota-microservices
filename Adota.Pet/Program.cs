var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


app.MapGet("pets/{id}", (string id) =>
{
    return Results.Ok(id);
});

app.Run();
