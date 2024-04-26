namespace Tech_Inventory.Application.Features.ProjectFeature.GetProjectsList;

public sealed record GetProjectsListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
