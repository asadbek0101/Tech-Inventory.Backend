namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektLocations;

public sealed record GetLocationsResponse
{
    public int Id { get; set; }
    public string NameAndAddress { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
