using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UserFeature.CreateUser;

public sealed record CreateUserRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string RoleValue { get; set; }
    public string RoleName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; } 
}
