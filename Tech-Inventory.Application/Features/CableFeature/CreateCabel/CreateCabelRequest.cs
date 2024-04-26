using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.CreateCabel;

public sealed record CreateCabelRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public int CabelTypeId { get; set; }
    public string Meter {  get; set; }
    public string? Info { get; set; }
    public CabelTypes CabelType { get; set; }
}
