namespace Tech_Inventory.Application.Features.CounterFeature.DeleteCounter;

public sealed record DeleteCounterResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
