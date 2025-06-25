using Application.Todos.Queries;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Todos.Handlers;

public class GetAllTodosHandler
{
    private readonly ITodoReadRepository _repository;

    public GetAllTodosHandler(ITodoReadRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Todo>> HandleAsync(GetAllTodosQuery query) => _repository.GetAllAsync();
}
