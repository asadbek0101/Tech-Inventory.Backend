namespace Tech_Inventory.Application.Features.CableFeature.GetOneCabel;

public sealed record GetOneCabelResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int CabelTypeId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Info { get; set; }
}
