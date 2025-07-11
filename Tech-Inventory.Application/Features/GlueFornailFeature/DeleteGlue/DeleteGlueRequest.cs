using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.DeleteGlue;

public sealed record DeleteGlueRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
