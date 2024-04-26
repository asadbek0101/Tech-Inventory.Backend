using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;

public sealed record GetAllObyektsResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Name { get; set; }
    public string Home { get; set; }
    public string Street { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Info { get; set; }
    public string ConnectionType { get; set; }
}
