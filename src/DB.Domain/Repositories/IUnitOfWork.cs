namespace DB.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();

}