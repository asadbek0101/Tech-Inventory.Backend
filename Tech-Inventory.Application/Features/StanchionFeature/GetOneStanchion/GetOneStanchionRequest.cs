using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StanchionFeature.GetOneStanchion;

public sealed record GetOneStanchionRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
