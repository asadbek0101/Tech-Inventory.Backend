namespace Tech_Inventory.Application.Auth.LoginUser;

public sealed record LoginUserResponse
{
    public string Token { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }
    public Exception exception { get; set; }
}
