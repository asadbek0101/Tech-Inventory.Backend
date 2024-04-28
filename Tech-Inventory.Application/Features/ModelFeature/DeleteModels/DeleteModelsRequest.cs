using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ModelFeature.DeleteModels;

public sealed record DeleteModelsRequest : IRequest<ApiResponse>
{
    public List<int> ModelIds { get; set; }
}
