using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AvtomatFeature.CreateAvtomat;

public sealed record CreateAvtomatRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }

}
