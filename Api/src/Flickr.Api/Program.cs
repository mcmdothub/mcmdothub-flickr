using Flickr.Api.Services.Interfaces;
using Flickr.Api.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Flickr.Api.Middleware;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Set the console title
Console.Title = "Flickr.Api";

// Explicitly load the .env file and ensure it's read correctly
string envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
if (File.Exists(envFilePath))
{
    Env.Load(envFilePath);
    Console.WriteLine("Environment variables loaded from .env file.");
}
else
{
    Console.WriteLine($"No .env file found at {envFilePath}. Ensure the file exists.");
}

// Debug log to ensure environment variables are loaded
var apiKey = Environment.GetEnvironmentVariable("FLICKR_API_KEY");
if (apiKey == null)
{
    Console.WriteLine("FLICKR_API_KEY is not set.");
}
else
{
    Console.WriteLine($"FLICKR_API_KEY is set");
}

// Check if running in a Docker container
var isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

// Configure Kestrel to handle HTTPS only in non-Docker environments
builder.WebHost.ConfigureKestrel(options =>
{
    if (!isDocker)
    {
        options.ListenAnyIP(7106, listenOptions =>
        {
            listenOptions.UseHttps(); // HTTPS for local development
        });
    }

    options.ListenAnyIP(8080); // HTTP for Docker
});


builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Flickr API",
        Version = "v1.0",
        Description = "Flickr is an online photo management and sharing application",
        Contact = new OpenApiContact
        {
            Name = "mcmdothub",
            Email = string.Empty,
            Url = new Uri("https://github.com/mcmdothub"),
        },
    });
});

builder.Services.AddHttpClient<IFlickrPhotosService, FlickrPhotosService>();

var allowedOrigins = builder.Configuration["ALLOWED_ORIGINS"]?.Split(",") ?? Array.Empty<string>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            //policy.WithOrigins(
            //"http://127.0.0.1:5500",                   // VS Code - Live Server
            //"http://localhost:5000/",                  // [webpack-dev-server] Loopback: http://localhost:5000/, http://[::1]:5000/
            //"http://172.17.16.1:5000",                 // [webpack-dev-server] On Your Network (IPv4): http://172.17.16.1:5000/
            //"https://your-production-url.com")         // On Cloud
            //      .AllowAnyHeader()
            //      .AllowAnyMethod();

            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// API versioning to keep compatibility with future versions
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (isDocker || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use HTTPS redirection only if not in Docker
if (!isDocker)
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
