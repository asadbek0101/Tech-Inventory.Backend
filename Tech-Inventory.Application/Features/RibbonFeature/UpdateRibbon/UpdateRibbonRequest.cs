using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RibbonFeature.UpdateRibbon;

public sealed record UpdateRibbonRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
