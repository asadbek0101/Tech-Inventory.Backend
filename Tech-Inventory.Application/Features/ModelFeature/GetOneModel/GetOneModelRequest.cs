using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ModelFeature.GetOneModel;

public sealed record GetOneModelRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
