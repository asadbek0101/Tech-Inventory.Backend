namespace Tech_Inventory.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}
