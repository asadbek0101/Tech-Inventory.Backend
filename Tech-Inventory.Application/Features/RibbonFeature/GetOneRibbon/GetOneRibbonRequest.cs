using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RibbonFeature.GetOneRibbon;

public sealed record GetOneRibbonRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
