namespace Tech_Inventory.Application.Features.UserFeature.GetOneUser;

public sealed record GetOneUserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
