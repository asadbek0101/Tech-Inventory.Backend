using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AvtomatFeature.UpdateAvtomat;

public sealed record UpdateAvtomatRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Group { get; set; }
    public string Info { get; set; }
}
