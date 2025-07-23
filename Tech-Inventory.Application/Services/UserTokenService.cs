using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Services;

public class UserTokenService : IUserTokenService
{
    private readonly IUserTokenRepository _repository;

    public UserTokenService(IUserTokenRepository repository)
    {
        _repository = repository;
    }

    public Task SaveTokenAsync(int userId, string token, CancellationToken cancellationToken)
    {
        return _repository.SaveAsync(userId, token, cancellationToken);
    }

    public Task<string?> GetSavedTokenAsync(int userId)
    {
        return _repository.GetAsync(userId);
    }
}
