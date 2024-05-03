namespace Tech_Inventory.Application.Features.BoxFeature.GetOneBox;

public sealed record GetOneBoxResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int TypeId { get; set; }
    public string? Info { get; set; }
}
