namespace Tech_Inventory.Application.Features.UpsFeature.GetOneUps;

public sealed record GetOneUpsReponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Power { get; set; }
    public string Info { get; set; }
}
