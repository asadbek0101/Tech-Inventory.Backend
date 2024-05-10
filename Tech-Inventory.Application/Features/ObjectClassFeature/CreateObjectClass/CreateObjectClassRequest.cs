using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.CreateObjectClass;

public sealed record CreateObjectClassRequest : IRequest<ApiResponse>
{
    public int ObjectClassTypeId { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
}
