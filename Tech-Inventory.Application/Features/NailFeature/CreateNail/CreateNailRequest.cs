using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NailFeature.CreateNail;

public sealed record CreateNailRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
}
