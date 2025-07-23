using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Persistence.Repositories;

public class UserTokenRepository : IUserTokenRepository
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UserTokenRepository(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        this._context = context;
        this._unitOfWork = unitOfWork;
    }

    public async Task SaveAsync(int userId, string token, CancellationToken cancellationToken)
    {
        var existing = await _context.UserTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        if (existing != null)
        {
            existing.Token = token;
        }
        else
        {
            _context.UserTokens.Add(new UserToken { UserId = userId, Token = token });
        }
        await _unitOfWork.Save(cancellationToken);
    }

    public async Task<string?> GetAsync(int userId)
    {
        return await _context.UserTokens
            .Where(x => x.UserId == userId)
            .Select(x => x.Token)
            .FirstOrDefaultAsync();
    }
}
