using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    //public int UserId => Convert.ToInt32(_httpContextAccessor.HttpContext?.Request?.Headers["userId"].ToString());
    public int UserId => 1;

}
