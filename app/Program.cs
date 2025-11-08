using app.Models;
using MongoDB.Driver;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));


builder.Services.AddSingleton<IMongoClient>(sp =>
{
    // Prefer the standard GetConnectionString helper (works with User Secrets),
    // fall back to explicit key if needed.
    var connString = builder.Configuration.GetConnectionString("DefaultConnection")
                     ?? builder.Configuration["ConnectionStrings:DefaultConnection"];

    if (string.IsNullOrWhiteSpace(connString))
    {
        throw new InvalidOperationException(
            "Connection string 'DefaultConnection' not found. " +
            "Set it via User Secrets: dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"Server=...;Database=...;User Id=...;Password=...;\""
        );
    }

    return new MongoClient(connString);
});


builder.Services.AddSingleton(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return mongoClient.GetDatabase(settings.DatabaseName);
});

builder.Services.AddControllers();



// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}




app.UseHttpsRedirection();





app.MapControllers();
app.Run();


