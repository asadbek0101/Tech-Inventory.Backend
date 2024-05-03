using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CounterFeature.GetOneCounter;

public sealed record GetOneCounterRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
