using Domain.Entities;

namespace Domain.Repositories;

public interface ITodoReadRepository
{
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(int id);
}
