namespace Domain.Repositories;

public interface IUnitOfWork
{
    ITodoRepository Todos { get; }
    Task<int> SaveChangesAsync();
}
