using Metro_Line_Management.Data;
using Metro_Line_Management.Data.Repositories;
using Metro_Line_Management.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<Metro_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddScoped<Lines_Repository>();
builder.Services.AddScoped<Stations_Repository>();
builder.Services.AddScoped<Lines_Service>();
builder.Services.AddScoped<Stations_Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
