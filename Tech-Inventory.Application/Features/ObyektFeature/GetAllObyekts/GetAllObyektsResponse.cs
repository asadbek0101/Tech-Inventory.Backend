namespace Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;

public sealed record GetAllObyektsResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string UpdatedByUserName { get; set; }
    public string CreatedByUserName { get; set; }
    public string NameAndAddress { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Info { get; set; }
    public string ConnectionType { get; set; }
    public string Project { get; set; }
    public string Owner { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
}
