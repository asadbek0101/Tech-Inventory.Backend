namespace Tech_Inventory.Application.Features.CounterFeature.UpdateCounter;

public sealed record UpdateCounterResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
