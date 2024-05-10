namespace Tech_Inventory.Application.Common.Exceptions;

public record BaseResponse
{
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Creator { get; set; }
    public string Updator { get; set; }
}
