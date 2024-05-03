using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NailFeature.DeleteNail;

public sealed record DeleteNailRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
