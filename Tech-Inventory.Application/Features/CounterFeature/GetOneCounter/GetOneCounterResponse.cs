namespace Tech_Inventory.Application.Features.CounterFeature.GetOneCounter;

public sealed record GetOneCounterResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string NumberOfConcern { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
