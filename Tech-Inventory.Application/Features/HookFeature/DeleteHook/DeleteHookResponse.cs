namespace Tech_Inventory.Application.Features.HookFeature.DeleteHook;

public sealed record DeleteHookResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
