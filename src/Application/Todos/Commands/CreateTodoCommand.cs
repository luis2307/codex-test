using Domain.Entities;

namespace Application.Todos.Commands;

public record CreateTodoCommand(string Title)
{
    public Todo ToEntity() => new Todo { Title = Title, IsCompleted = false };
}
