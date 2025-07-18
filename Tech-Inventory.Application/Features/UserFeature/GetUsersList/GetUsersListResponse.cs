namespace Tech_Inventory.Application.Features.UserFeature.GetUsersList;

public sealed record GetUsersListResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
