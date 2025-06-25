using System.Data;
using Dapper;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class TodoReadRepository : ITodoReadRepository
{
    private readonly IDbConnection _connection;

    public TodoReadRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        var sql = "SELECT Id, Title, IsCompleted FROM Todos";
        return await _connection.QueryAsync<Todo>(sql);
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        var sql = "SELECT Id, Title, IsCompleted FROM Todos WHERE Id = @Id";
        return await _connection.QuerySingleOrDefaultAsync<Todo>(sql, new { Id = id });
    }
}
