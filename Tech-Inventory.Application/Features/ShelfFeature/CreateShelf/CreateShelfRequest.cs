using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.CreateShelf;

public sealed record CreateShelfRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
    public ShelfTypes ShelfType { get; set; }
}
