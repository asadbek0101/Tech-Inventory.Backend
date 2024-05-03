namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetNumberOfOrdersList;

public sealed record GetNumberOfOrdersListResponse
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string RegionId { get; set; }
}
