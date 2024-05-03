namespace Tech_Inventory.Domain.Entities;

public class Shell : BaseEntity
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public ShellTypes ShellType { get; set; }
    public Obyekt Obyekt { get; set; }
}

public enum ShellTypes
{
    GofraShell = 1,
    PlasticShell = 2
}