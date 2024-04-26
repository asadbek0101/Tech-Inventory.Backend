using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SvetaforFeature.UpdateSvetafor;

public sealed record UpdateSvetaforRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string PortNumber { get; set; }
    public string Info { get; set; }
}
