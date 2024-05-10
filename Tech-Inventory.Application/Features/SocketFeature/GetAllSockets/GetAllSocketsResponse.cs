using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SocketFeature.GetAllSockets;

public sealed record GetAllSocketsResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
