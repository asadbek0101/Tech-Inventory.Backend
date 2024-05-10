using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.BoxFeature.UpdateBox;

public sealed record UpdateBoxRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int TypeId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
