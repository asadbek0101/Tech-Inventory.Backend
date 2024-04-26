using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UserFeature.DeleteUser;

public sealed record DeleteUserRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
