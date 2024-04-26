using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SvetaforFeature.GetOneSvetafor;

public sealed record GetOneSvetaforRequest : IRequest<ApiResponse>
{ 
    public int Id { get; set; }
}
