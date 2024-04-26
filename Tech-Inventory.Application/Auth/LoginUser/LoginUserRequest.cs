using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Auth.LoginUser;

public sealed class LoginUserRequest : IRequest<ApiResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
