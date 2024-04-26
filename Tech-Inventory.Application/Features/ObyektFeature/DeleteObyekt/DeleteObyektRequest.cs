using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.DeleteObyekt;

public sealed record DeleteObyektRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
