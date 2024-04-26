namespace Tech_Inventory.Application.Features.AvtomatFeature.GetAllAvtomats;

public sealed record GetAllAvtomatsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string Info { get; set; }
}
