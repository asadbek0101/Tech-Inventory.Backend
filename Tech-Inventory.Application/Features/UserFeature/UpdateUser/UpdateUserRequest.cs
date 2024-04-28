using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UserFeature.UpdateUser;

public sealed record UpdateUserRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string RoleName { get; set; }
}
