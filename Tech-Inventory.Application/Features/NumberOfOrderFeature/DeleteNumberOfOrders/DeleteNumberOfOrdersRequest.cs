using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.DeleteNumberOfOrders;

public sealed record DeleteNumberOfOrdersRequest : IRequest<ApiResponse>
{
    public List<int> NumberOfOrderIds { get; set; }
}
