using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UpsFeature.DeleteUps;

public sealed record DeleteUpsRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
