using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetOneModel;

public sealed record GetOneModelResponse
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Type { get; set; }
}
