namespace Tech_Inventory.Application.Features.SvetaforFeature.GetOneSvetafor;

public sealed record GetOneSvetaforResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string PortNumber { get; set; }
    public string Info { get; set; }
}
