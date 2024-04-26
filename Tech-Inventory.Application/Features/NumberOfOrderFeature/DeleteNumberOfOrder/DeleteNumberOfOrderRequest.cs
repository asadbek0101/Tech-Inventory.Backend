using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.DeleteNumberOfOrder;

public sealed record DeleteNumberOfOrderRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
