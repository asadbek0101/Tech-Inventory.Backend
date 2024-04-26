using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConTypeFeature.CreateConType;

public sealed record CreateConTypeRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int? ModelId { get; set; }
    public string? NumberOfPort {  get; set; }
    public string? SerialNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public ConnectionTypes Type { get; set; }
}
