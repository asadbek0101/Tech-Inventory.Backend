using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StanchionFeature.DeleteStanchion;

public sealed record DeleteStanchionRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
