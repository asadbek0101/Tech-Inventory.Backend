namespace Tech_Inventory.Application.Features.CounterFeature.CreateCounter;

public sealed record CreateCounterResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
