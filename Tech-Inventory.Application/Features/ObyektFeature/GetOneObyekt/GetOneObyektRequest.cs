using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public sealed record GetOneObyektRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
