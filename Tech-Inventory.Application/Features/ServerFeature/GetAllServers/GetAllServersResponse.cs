using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ServerFeature.GetAllServers;

public sealed record GetAllServersResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Ip { get; set; }
    public string? Info { get; set; }
}
