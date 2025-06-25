using Domain.Entities;

namespace Application.Todos.Commands;

public record UpdateTodoCommand(int Id, string Title, bool IsCompleted)
{
    public Todo ToEntity() => new Todo { Id = Id, Title = Title, IsCompleted = IsCompleted };
}
