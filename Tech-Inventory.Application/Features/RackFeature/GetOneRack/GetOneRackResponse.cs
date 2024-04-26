namespace Tech_Inventory.Application.Features.RackFeature.GetOneRack;

public sealed record GetOneRackResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int ObyektId { get; set; }
    public int ProjectorTypeId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Model { get; set; }
}
