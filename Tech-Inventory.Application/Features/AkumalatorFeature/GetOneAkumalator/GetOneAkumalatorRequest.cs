using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetOneAkumalator;

public sealed record GetOneAkumalatorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
