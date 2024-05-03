using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Auth.ResetPassword;

public sealed record ResetPasswordRequest : IRequest<ApiResponse>
{
    public int UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
