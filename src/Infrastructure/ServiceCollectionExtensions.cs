using System.Data;
using Dapper;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IDbConnection>(_ => new SqliteConnection(connectionString));
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<ITodoReadRepository, TodoReadRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
