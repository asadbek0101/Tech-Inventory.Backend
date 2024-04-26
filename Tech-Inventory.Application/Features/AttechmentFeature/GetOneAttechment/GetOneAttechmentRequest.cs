using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttechmentFeature.GetOneAttechment;

public sealed record GetOneAttechmentRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
