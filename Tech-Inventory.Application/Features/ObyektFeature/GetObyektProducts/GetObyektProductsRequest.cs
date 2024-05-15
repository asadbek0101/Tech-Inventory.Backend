using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektProducts;

public sealed record GetObyektProductsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
}
