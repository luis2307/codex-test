using Application.Todos.Queries;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Todos.Handlers;

public class GetTodoByIdHandler
{
    private readonly ITodoReadRepository _repository;

    public GetTodoByIdHandler(ITodoReadRepository repository)
    {
        _repository = repository;
    }

    public Task<Todo?> HandleAsync(GetTodoByIdQuery query) => _repository.GetByIdAsync(query.Id);
}
