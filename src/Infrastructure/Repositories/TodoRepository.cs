using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        await Task.CompletedTask;
        return todo;
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = new Todo { Id = id };
        _context.Todos.Remove(entity);
        await Task.CompletedTask;
    }
}
