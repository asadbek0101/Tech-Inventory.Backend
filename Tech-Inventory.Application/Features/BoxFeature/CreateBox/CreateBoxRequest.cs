using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.BoxFeature.CreateBox;

public sealed record CreateBoxRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int TypeId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
