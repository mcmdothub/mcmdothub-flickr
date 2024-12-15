using Flickr.Api.Services.Interfaces;
using Flickr.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Set the console title
Console.Title = "Flickr.Api";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Flickr API",
        Version = "v1",
        Description = "Flickr is an online photo management and sharing application",
        Contact = new OpenApiContact
        {
            Name = "Cygni",
            Email = string.Empty,
            Url = new Uri("https://cygni.se/"),
        },
    });
});

builder.Services.AddHttpClient<IFlickrPhotosService, FlickrPhotosService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(
            "http://127.0.0.1:5500",                   // VS Code - Live Server
            "http://localhost:5000/",                  // [webpack-dev-server] Loopback: http://localhost:5000/, http://[::1]:5000/
            "http://172.17.16.1:5000",                 // [webpack-dev-server] On Your Network (IPv4): http://172.17.16.1:5000/
            "https://your-production-url.com")         // On Cloud
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
