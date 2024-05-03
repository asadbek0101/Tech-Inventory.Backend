using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.BoxFeature.GetOneBox;

public sealed record GetOneBoxRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
