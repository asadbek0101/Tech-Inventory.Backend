using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetModelsList;

public sealed record GetModelsListRequest : IRequest<ApiResponse>
{
    public ModelTypes Type { get; set; }
}
