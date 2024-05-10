using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UpsFeature.UpdateUps;

public sealed record UpdateUpsRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Power { get; set; }
    public string Info { get; set; }
}
