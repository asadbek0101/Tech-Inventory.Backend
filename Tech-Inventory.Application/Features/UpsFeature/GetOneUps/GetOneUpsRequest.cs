using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UpsFeature.GetOneUps;

public sealed record GetOneUpsRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
