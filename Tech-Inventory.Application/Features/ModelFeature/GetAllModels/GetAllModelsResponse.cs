using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetAllModels;

public sealed record GetAllModelsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string? Info {  get; set; }
}
