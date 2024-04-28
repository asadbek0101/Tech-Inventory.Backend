using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UserFeature.CreateUser;

public sealed record CreateUserRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public string RoleName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}
