namespace easypost_api.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}