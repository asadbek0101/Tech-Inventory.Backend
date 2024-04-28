namespace Tech_Inventory.Application.Features.UserFeature.GetAllusers;

public sealed record GetAllUsersResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
}
