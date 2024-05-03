using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NailFeature.UpdateNail;

public sealed record UpdateNailRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
}
