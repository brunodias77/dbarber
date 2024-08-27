using DB.Domain.Repositories;
using DB.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task Commit()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao salvar as alterações da entidade: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Exceção interna: " + ex.InnerException.Message);
            }

            throw; //
        }
    }
}