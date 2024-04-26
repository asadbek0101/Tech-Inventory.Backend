namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetOneNumberOfOrder;

public sealed record GetOneNumberOfOrderResponse
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
}
