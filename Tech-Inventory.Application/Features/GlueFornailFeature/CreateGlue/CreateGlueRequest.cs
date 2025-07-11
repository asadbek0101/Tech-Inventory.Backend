using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.CreateGlue;

public sealed record CreateGlueRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string CountOfCrate { get; set; }
    public string? Info { get; set; }
}
