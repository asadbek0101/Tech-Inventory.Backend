using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateShell
{
    public string Meter { get; set; }
    public string? Info { get; set; }
    public ShellTypes ShellType { get; set; }
}
