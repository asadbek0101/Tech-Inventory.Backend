using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AvtomatFeature.GetOneAvtomat;

public sealed record GetOneAvtomatRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
