namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetOneObjectClassType;

public sealed record GetOneObjectClassTypeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
}
