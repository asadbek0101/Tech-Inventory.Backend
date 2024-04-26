namespace Tech_Inventory.Application.Common.Exceptions;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public bool IsError { get; set; }
    public object? Data { get; set; }

}

public enum ResponseType
{
    Success, Failed
}
