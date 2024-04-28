using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.UpdateModel;

public sealed record UpdateModelRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
    public ModelTypes Type { get; set; }
}
