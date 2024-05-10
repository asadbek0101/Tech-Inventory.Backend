using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetAllTerminalServers;

public sealed record GetAllTerminalServersResponse : BaseResponse
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
