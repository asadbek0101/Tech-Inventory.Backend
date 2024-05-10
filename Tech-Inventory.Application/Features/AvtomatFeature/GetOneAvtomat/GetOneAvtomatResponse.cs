namespace Tech_Inventory.Application.Features.AvtomatFeature.GetOneAvtomat;

public sealed record GetOneAvtomatResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
