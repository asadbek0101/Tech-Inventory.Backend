using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ITechInventoryDB _context;

    public UnitOfWork(ITechInventoryDB context)
    {
        _context = context;
    }
    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
