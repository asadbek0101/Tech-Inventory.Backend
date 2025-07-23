namespace Tech_Inventory.Application.Common.Interfaces;

public interface IUserTokenService
{
    Task SaveTokenAsync(int userId, string token, CancellationToken cancellationToken);
    Task<string?> GetSavedTokenAsync(int userId);
}
