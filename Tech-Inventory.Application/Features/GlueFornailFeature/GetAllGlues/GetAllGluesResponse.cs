using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.GetAllGlues;

public sealed record GetAllGluesResponse : BaseResponse
{
    public int Id { get; set; }
    public string CountOfCrate { get; set; }
    public string? Info { get; set; }
}
