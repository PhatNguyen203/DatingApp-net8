using DatingApp.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => 
{
	options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
