using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
