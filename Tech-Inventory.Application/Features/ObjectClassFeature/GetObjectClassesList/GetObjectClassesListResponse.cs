namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassesList;

public sealed record GetObjectClassesListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
