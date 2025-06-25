using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Default") ?? "Data Source=todos.db";
builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

app.MapControllers();
app.Run();
