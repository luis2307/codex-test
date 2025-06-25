using Application.Todos.Commands;
using Domain.Repositories;

namespace Application.Todos.Handlers;

public class UpdateTodoHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTodoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(UpdateTodoCommand command)
    {
        await _unitOfWork.Todos.UpdateAsync(command.ToEntity());
        await _unitOfWork.SaveChangesAsync();
    }
}
