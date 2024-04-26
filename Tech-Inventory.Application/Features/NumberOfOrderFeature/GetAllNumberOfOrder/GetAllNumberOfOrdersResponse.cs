namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetAllNumberOfOrder;

public sealed record GetAllNumberOfOrdersResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
}
