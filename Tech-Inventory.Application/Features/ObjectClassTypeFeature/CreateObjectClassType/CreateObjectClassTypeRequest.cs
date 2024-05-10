using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.CreateObjectClassType;

public sealed record CreateObjectClassTypeRequest : IRequest<ApiResponse>
{
    public string Name { get; set; }
    public string? Info { get; set; }
}
