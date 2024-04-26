using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.DeleteAkumalator;

public sealed record DeleteAkumalatorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
