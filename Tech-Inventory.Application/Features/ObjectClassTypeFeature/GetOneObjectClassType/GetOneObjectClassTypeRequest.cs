using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetOneObjectClassType;

public sealed record GetOneObjectClassTypeRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
