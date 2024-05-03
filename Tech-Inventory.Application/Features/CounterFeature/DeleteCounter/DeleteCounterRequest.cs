using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CounterFeature.DeleteCounter;

public sealed record DeleteCounterRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
