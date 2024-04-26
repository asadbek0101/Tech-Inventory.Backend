using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttechmentFeature.DeleteAttechment;

public sealed record DeleteAttechmentRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
