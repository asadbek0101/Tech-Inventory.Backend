using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CableFeature.GetAllCabels;

public sealed record GetAllCabelsResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Meter { get; set; }
    public string Info { get; set; }
}
