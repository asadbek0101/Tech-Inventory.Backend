using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NailFeature.GetOneNail;

public sealed record GetOneNailRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
