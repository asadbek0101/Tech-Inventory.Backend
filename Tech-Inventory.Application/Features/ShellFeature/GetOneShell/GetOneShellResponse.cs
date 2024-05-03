using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.GetOneShell;

public sealed record GetOneShellResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public ShellTypes ShellType { get; set; }
}
