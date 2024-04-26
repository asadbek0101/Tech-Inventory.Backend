using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AvtomatFeature.DeleteAvtomat;

public sealed record DeleteAvtomatRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
