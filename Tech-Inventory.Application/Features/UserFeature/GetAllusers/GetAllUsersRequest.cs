using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UserFeature.GetAllusers;

public sealed record GetAllUsersRequest : IRequest<ApiResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
