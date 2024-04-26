namespace Tech_Inventory.Application.Features.SwitchFeature.GetOneSwitch;

public sealed record GetOneSwitchResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int ObyektId { get; set; }
    public int SwitchTypeId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string PortNumber { get; set; }
    public string Info { get; set; }
}
