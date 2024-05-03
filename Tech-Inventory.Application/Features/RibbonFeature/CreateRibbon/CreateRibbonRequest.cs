using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RibbonFeature.CreateRibbon;

public sealed record CreateRibbonRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
