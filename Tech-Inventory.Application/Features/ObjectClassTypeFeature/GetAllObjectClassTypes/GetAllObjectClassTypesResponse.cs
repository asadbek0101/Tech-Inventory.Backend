namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetAllObjectClassTypes;

public sealed record GetAllObjectClassTypesResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
    public string Creator { get; set; }
    public string? Updator { get; set; }
}
