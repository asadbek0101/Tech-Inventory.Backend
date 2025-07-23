using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateShell
{
    public string Meter { get; set; }
    public string? Info { get; set; }
    public ShellTypes ShellType { get; set; }
}
