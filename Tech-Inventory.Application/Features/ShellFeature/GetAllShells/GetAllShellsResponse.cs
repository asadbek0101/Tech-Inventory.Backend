using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.GetAllShells;

public sealed record GetAllShellsResponse
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public ShellTypes ShellType { get; set; }
}
