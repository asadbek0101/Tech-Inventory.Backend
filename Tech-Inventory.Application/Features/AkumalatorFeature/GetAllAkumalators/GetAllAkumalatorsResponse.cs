using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetAllAkumalators;

public sealed record GetAllAkumalatorsResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Count { get; set; }
    public string Power { get; set; }
    public string Info { get; set; }
}
