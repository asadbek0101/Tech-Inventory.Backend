using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StabilizerFeature.DeleteStabilizer;

public sealed record DeleteStabilizerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
