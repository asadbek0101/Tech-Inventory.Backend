namespace Tech_Inventory.Application.Features.ProjectFeature.GetAllProjects;

public sealed record GetAllProjectsResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public DateTime CreatedDate { get; set; }
}
