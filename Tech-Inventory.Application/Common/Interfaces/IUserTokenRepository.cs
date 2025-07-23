namespace Tech_Inventory.Application.Common.Interfaces;

public interface IUserTokenRepository
{
    Task SaveAsync(int userId, string token, CancellationToken cancellationToken);
    Task<string?> GetAsync(int userId);
}
