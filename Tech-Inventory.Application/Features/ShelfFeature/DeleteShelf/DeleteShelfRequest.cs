using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ShelfFeature.DeleteShelf;

public sealed record DeleteShelfRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
