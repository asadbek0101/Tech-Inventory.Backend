using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RibbonFeature.DeleteRibbon;

public sealed record DeleteRibbonRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
