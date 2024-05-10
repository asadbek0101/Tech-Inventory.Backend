using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetOneObjectClass;

public sealed record GetOneObjectClassRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
