namespace Tech_Inventory.Application.Features.UserFeature.GetOneUser;

public sealed record GetOneUserResponse
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public object Role { get; set; }

}
