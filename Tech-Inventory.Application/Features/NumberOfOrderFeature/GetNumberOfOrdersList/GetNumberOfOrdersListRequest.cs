using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetNumberOfOrdersList;

public sealed record GetNumberOfOrdersListRequest : IRequest<ApiResponse>
{
    public int ProjectId { get; set; }
}
