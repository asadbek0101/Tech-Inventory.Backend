namespace Tech_Inventory.Application.Features.ProjectFeature.GetOneProject;

public sealed record GetOneProjectResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
}
