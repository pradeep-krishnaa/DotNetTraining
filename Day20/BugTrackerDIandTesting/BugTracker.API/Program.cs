using BugTracker.API.Extensions;
using BugTracker.Application.Services;
using BugTracker.Core.Interfaces;
using BugTracker.Infrastructure.Data;
using BugTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application services
builder.Services.AddScoped<IBugService, BugService>();
builder.Services.AddSingleton<IBugRepository, BugRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //injecting DbContext

var app = builder.Build();

app.UseGlobalExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
