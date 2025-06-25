using Application.Todos.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Todos.Handlers;

public class CreateTodoHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTodoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Todo> HandleAsync(CreateTodoCommand command)
    {
        var entity = command.ToEntity();
        await _unitOfWork.Todos.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }
}
