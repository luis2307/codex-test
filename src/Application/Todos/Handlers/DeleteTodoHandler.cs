using Application.Todos.Commands;
using Domain.Repositories;

namespace Application.Todos.Handlers;

public class DeleteTodoHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTodoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteTodoCommand command)
    {
        await _unitOfWork.Todos.DeleteAsync(command.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
