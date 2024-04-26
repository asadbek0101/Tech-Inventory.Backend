using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.CreateNumberOfOrder;

public sealed record CreateNumberOfOrderRequest : IRequest<ApiResponse>
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
}
