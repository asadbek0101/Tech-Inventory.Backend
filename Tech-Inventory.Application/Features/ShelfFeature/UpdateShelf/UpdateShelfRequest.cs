using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ShelfFeature.UpdateShelf;

public sealed record UpdateShelfRequest: IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ShelfTypeId { get; set; }
    public string digitNumber { get; set; }
    public string? Info { get; set; }
}
