using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.GetAllGlues;

public sealed record GetAllGluesRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
}
