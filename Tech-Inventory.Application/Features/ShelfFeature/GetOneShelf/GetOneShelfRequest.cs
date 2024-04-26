using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;

public sealed record GetOneShelfRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
