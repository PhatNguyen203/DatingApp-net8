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
builder.Services.AddCors(options => 
{
	options.AddPolicy("CorsPolicy", policy => 
	{
		policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
	});
});
var app = builder.Build();

app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
