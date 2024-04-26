using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SvetaforFeature.DeleteSvetafor;

public sealed record DeleteSvetaforRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
