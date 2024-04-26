using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.CreateModel;

public sealed record CreateModelRequest : IRequest<ApiResponse>
{
    public string Name { get; set; }
    public string? Info { get; set; }
    public ModelTypes Type { get; set; }
}
