using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.BoxFeature.DeleteBox;

public sealed record DeleteBoxRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
