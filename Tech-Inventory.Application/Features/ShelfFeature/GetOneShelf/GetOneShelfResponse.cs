namespace Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;

public sealed record GetOneShelfResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int ObyektId { get; set; }
    public int ShelfTypeId { get; set; }
    public string digitNumber { get; set; }
    public string Info { get; set; }
}
