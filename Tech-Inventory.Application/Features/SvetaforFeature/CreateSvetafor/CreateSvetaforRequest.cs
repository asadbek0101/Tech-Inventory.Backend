using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.CreateSvetafor;

public sealed record CreateSvetaforRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public SvetaforTypes SvetaforType { get; set; }
}
