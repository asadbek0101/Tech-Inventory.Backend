using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StabilizerFeature.GetOneStabilizer;

public sealed record GetOneStabilizerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
