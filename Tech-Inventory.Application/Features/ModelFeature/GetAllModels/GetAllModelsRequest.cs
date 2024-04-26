using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetAllModels;

public sealed record GetAllModelsRequest : IRequest<ApiResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public ModelTypes Type { get; set; } = ModelTypes.All;
    public string? SearchValue { get; set; }
}
