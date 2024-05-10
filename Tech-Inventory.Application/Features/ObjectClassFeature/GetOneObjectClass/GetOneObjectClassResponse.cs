namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetOneObjectClass;

public sealed record GetOneObjectClassResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
}
