using Application.Todos.Commands;
using Application.Todos.Handlers;
using Application.Todos.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly CreateTodoHandler _create;
    private readonly UpdateTodoHandler _update;
    private readonly DeleteTodoHandler _delete;
    private readonly GetAllTodosHandler _getAll;
    private readonly GetTodoByIdHandler _getById;

    public TodoController(
        CreateTodoHandler create,
        UpdateTodoHandler update,
        DeleteTodoHandler delete,
        GetAllTodosHandler getAll,
        GetTodoByIdHandler getById)
    {
        _create = create;
        _update = update;
        _delete = delete;
        _getAll = getAll;
        _getById = getById;
    }

    [HttpGet]
    public Task<IEnumerable<Todo>> Get() => _getAll.HandleAsync(new GetAllTodosQuery());

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> Get(int id)
    {
        var todo = await _getById.HandleAsync(new GetTodoByIdQuery(id));
        if (todo is null) return NotFound();
        return todo;
    }

    [HttpPost]
    public Task<Todo> Post([FromBody] CreateTodoCommand command) => _create.HandleAsync(command);

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateTodoCommand command)
    {
        await _update.HandleAsync(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _delete.HandleAsync(new DeleteTodoCommand(id));
        return NoContent();
    }
}
