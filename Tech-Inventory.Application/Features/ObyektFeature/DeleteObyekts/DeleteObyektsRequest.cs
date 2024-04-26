using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.DeleteObyekts;

public sealed record DeleteObyektsRequest : IRequest<ApiResponse>
{
    public List<int> ObyektIds { get; set; }
}
