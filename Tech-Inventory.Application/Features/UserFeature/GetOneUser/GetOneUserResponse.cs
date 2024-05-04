namespace Tech_Inventory.Application.Features.UserFeature.GetOneUser;

public sealed record GetOneUserResponse
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Region { get; set; }
    public object Role { get; set; }
    public string RoleName { get; set; }
    public string Image {  get; set; }

}
