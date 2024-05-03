namespace Tech_Inventory.Domain.Entities;

public class Hook : BaseEntity
{
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public HookTypes HookType { get; set; }
    public Obyekt Obyekt { get; set; }
}

public enum HookTypes
{
    SipHook = 1,
    CabelHook = 2,
}
