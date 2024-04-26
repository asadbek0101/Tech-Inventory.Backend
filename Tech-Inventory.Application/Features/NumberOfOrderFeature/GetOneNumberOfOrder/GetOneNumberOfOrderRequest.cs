using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetOneNumberOfOrder;

public sealed record GetOneNumberOfOrderRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
