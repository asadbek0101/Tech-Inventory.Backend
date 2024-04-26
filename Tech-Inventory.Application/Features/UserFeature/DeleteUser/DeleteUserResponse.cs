namespace Tech_Inventory.Application.Features.UserFeature.DeleteUser;

public sealed record DeleteUserResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
