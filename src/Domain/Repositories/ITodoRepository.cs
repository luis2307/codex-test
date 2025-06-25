using Domain.Entities;

namespace Domain.Repositories;

public interface ITodoRepository
{
    Task<Todo> AddAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(int id);
}
