using MongoDB.Driver;
using MongoDB.Bson;
using BackEnd.Collections;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    "appsettings.local.json",
    optional: true,
    reloadOnChange: true
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SmartHack Exam API",
        Version = "v1",
        Description = "API for managing exam documents in MongoDB"
    });
});
builder.Services.AddHealthChecks();

var connectionString = builder.Configuration["MongoDB:ConnectionString"];
var settings = MongoClientSettings.FromConnectionString(connectionString);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

builder.Services.AddSingleton<IMongoClient>(new MongoClient(settings));

builder.Services
    .AddScoped<ExamsCollection>(sp
            => new(
                sp.GetRequiredService<IMongoClient>(),
                builder.Configuration["MongoDB:DatabaseName"] ?? "db",
                builder.Configuration["MongoDB:ExamsCollectionName"] ?? "exams"));

builder.Services
    .AddScoped<SubmissionsCollection>(sp
            => new(
                sp.GetRequiredService<IMongoClient>(),
                builder.Configuration["MongoDB:DatabaseName"] ?? "db",
                builder.Configuration["MongoDB:SubmissionsCollectionName"] ?? "submissions"));

var app = builder.Build();

try
{
    var mongoClient = app.Services.GetRequiredService<IMongoClient>();
    var result = mongoClient.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
}
catch (Exception ex)
{
    Console.WriteLine($"MongoDB connection failed: {ex.Message}");
}

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHack Exam API v1");
        options.RoutePrefix = string.Empty; // Swagger UI at root
    });
}

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
