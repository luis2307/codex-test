using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ITodoRepository Todos { get; }

    public UnitOfWork(AppDbContext context, ITodoRepository todoRepository)
    {
        _context = context;
        Todos = todoRepository;
    }

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
