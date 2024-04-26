namespace Tech_Inventory.Application.Features.ProjectorFeature.GetOneProjector;

public sealed record GetOneProjectorResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ProjectorTypeId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Model { get; set; }
}
