using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UpsFeature.CreateUps;

public sealed record CreateUpsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Power { get; set; }
    public string Info { get; set; }
}
